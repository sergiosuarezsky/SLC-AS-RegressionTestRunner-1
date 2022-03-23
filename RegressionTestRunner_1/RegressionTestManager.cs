namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Newtonsoft.Json;
	using RegressionTestRunner.AutomationScripts;
	using RegressionTestRunner.Helpers;
	using RegressionTestRunner.RegressionTests;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Library.Automation;
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Net.Messages;

	public class RegressionTestManager
	{
		public static readonly string TestOutputDirectory = @"C:\RTManager\TestOutput";

		private const string RegressionTestProtocolName = "Skyline Regression Test Result Collector";
		private const int RegressionTestResultsTablePid = 100;

		private readonly IEngine engine;
		private readonly IDma agent;
		private readonly string[] testScripts;
		private readonly Dictionary<string, string> logFilePaths = new Dictionary<string, string>();
		private readonly Dictionary<string, DateTime> logFileCreationTimes = new Dictionary<string, DateTime>();

		public RegressionTestManager(IEngine engine, params string[] testScripts)
		{
			this.engine = engine;
			this.testScripts = testScripts;

			var agents = engine.GetDms().GetAgents().Where(x => x.State == Skyline.DataMiner.Library.Common.AgentState.Running);
			int currentAgentId = Skyline.DataMiner.Automation.Engine.SLNetRaw.ServerDetails.AgentID;
			agent = agents.FirstOrDefault(x => x.Id == currentAgentId);
		}

		public RegressionTestManager(IEngine engine, IDma agent, params string[] testScripts)
		{
			this.engine = engine;
			this.agent = agent;
			this.testScripts = testScripts;
		}

		public IEnumerable<string> TestScripts => testScripts;

		public void Run()
		{
			foreach (string testScript in testScripts)
			{
				ReportProgress($"Executing test {testScript}...");

				DateTime startTime = DateTime.Now;

				RegisterStartTime(testScript, startTime);

				try
				{
					engine.SendSLNetSingleResponseMessage(new ExecuteScriptMessage(agent.Id, testScript)
					{
						Options = new SA(new[]
						{
							"USER:cookie",
							"OPTIONS:0",
							"CHECKSETS:FALSE",
							"EXTENDED_ERROR_INFO",
							"DEFER:FALSE" // syncronous execution
						})
					});
				}
				catch (Exception e)
				{
					ReportProgress($"Something when wrong when running test {testScript} {e}");
				}

				DateTime endTime = DateTime.Now;

				ReportProgress($"Retrieve logging...");

				RegisterLogFilePath(testScript, startTime, endTime);

				ReportProgress($"Finished test {testScript}");
			}

			PushResultsToElement();
		}

		public void PushResultsToElement()
		{
			engine.Log(nameof(RegressionTestManager), nameof(PushResultsToElement), "Pushing results to Regression Test Collector element...");

			var rawElement = engine.FindElementsByProtocol(RegressionTestProtocolName).FirstOrDefault();
			if (rawElement == null) return;

			var dms = engine.GetDms();
			var element = dms.GetElement(rawElement.ElementName);
			var resultsTable = element.GetTable(RegressionTestResultsTablePid);

			foreach (string testScript in testScripts)
			{
				var entry = GetResultsTableEntry(testScript);
				engine.Log(nameof(RegressionTestManager), nameof(PushResultsToElement), $"Pushing: {String.Join(", ", entry)}...");

				if (resultsTable.RowExists(testScript))
				{
					resultsTable.SetRow(testScript, entry);
				}
				else
				{
					resultsTable.AddRow(entry);
				}
			}
		}

		private object[] GetResultsTableEntry(string scriptName)
		{
			DateTime runtime;
			if (!logFileCreationTimes.TryGetValue(scriptName, out runtime))
			{
				engine.Log(nameof(RegressionTestManager), nameof(GetResultsTableEntry), $"{scriptName} was not registered correctly");
				runtime = DateTime.MinValue;
			}

			return new object[]
			{
				scriptName,
				(int)WasTestSuccessful(scriptName),
				GetReason(scriptName),
				runtime.ToOADate(),
				null
			};
		}

		public bool TryGetLogging(string testScript, out string logging)
		{
			logging = String.Empty;
			if (!logFilePaths.TryGetValue(testScript, out string path)) return false;

			try
			{
				logging = File.ReadAllText(path);
				return true;
			}
			catch (Exception e)
			{
				engine.Log(nameof(RegressionTestManager), nameof(TryGetLogging), $"Unable to retrieve logging of file {path}: {e}");
				return false;
			}
		}

		public bool TryGetLogFilePath(string testScript, out string filePath)
		{
			filePath = String.Empty;
			if (!logFilePaths.TryGetValue(testScript, out string path)) return false;

			filePath = path;
			return true;
		}

		public RegressionTestStates WasTestSuccessful(string automationScript)
		{
			if (!TryGetLogging(automationScript, out string logging)) return RegressionTestStates.Unknown;
			if (logging.Contains("RT_PORTAL_FAIL")) return RegressionTestStates.Fail;
			return RegressionTestStates.OK;
		}

		public string GetReason(string testScript)
		{
			if (!TryGetLogFilePath(testScript, out string filePath)) return "Unable to find logging";

			IEnumerable<string> logLines;
			if (!TryGetLogFileLines(filePath, out logLines)) return "Unable to access logging";

			string reason = String.Empty;
			foreach (string line in logLines)
			{
				if (Regex.Matches(line, @"Posting to '.*' with body: ").Count <= 0) continue;

				int startIndex = line.IndexOf('{');
				int length = line.LastIndexOf('}') - startIndex + 1;

				try
				{
					string serializedPost = line.Substring(startIndex, length);
					var postBody = JsonConvert.DeserializeObject<PostBody>(serializedPost);
					reason = postBody.Value;
					break;
				}
				catch (Exception e)
				{
					engine.Log(nameof(RegressionTestManager), nameof(GetReason), $"Unable to deserialize the post message on line: {line} due to {e}");
				}
			}

			return reason;
		}

		private static bool TryGetLogFileLines(string filePath, out IEnumerable<string> lines)
		{
			lines = new string[0];

			try
			{
				lines = File.ReadLines(filePath);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void RegisterStartTime(string testScript, DateTime start)
		{
			logFileCreationTimes.Add(testScript, start);
		}

		private void RegisterLogFilePath(string testScript, DateTime start, DateTime end)
		{
			string outputFolderPath = Path.Combine(TestOutputDirectory, testScript);
			if (!Directory.Exists(outputFolderPath))
			{
				ReportProgress($"No test output directory found, expected location: {outputFolderPath}");
				return;
			}

			string logFilePath = String.Empty;
			DateTime creationTime;
			foreach (string filePath in Directory.EnumerateFiles(outputFolderPath))
			{
				creationTime = File.GetCreationTime(filePath);
				if (start <= creationTime && creationTime <= end)
				{
					logFilePath = filePath;
					break;
				}
			}

			logFilePaths.Add(testScript, logFilePath);
			ReportProgress($"Found log file: {logFilePath}");
		}

		private void ReportProgress(string progress)
		{
			if (ProgressReported == null) return;
			ProgressReported(this, new ProgressEventArgs(progress));
		}

		public event EventHandler<ProgressEventArgs> ProgressReported;
	}

	public enum RegressionTestStates
	{
		Fail = 0,
		OK = 1,
		Unknown = 2
	}
}
