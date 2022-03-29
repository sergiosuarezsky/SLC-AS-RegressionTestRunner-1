namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
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

		private readonly Dictionary<string, LogFile> logFiles = new Dictionary<string, LogFile>();

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
							"DEFER:FALSE" // synchronous execution
						})
					});
				}
				catch (Exception e)
				{
					ReportProgress($"Something when wrong when running test {testScript} {e}");
				}

				DateTime endTime = DateTime.Now;

				ReportProgress($"Retrieve logging...");

				RegisterLogFile(testScript, startTime, endTime);

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
			RegressionTestStates state;
			string reason;
			DateTime creationTime;

			if (!logFiles.TryGetValue(scriptName, out LogFile logFile))
			{
				state = RegressionTestStates.Unknown;
				reason = $"{scriptName} was not registered correctly";
				creationTime = DateTime.MinValue;
			}
			else
			{
				state = logFile.State;
				reason = logFile.Reason;
				creationTime = logFile.CreationTime;
			}

			return new object[]
			{
				scriptName,
				(int)state,
				reason,
				creationTime.ToOADate(),
				null
			};
		}

		public bool TryGetLogging(string testScript, out LogFile logging)
		{
			logging = null;
			if (!logFiles.TryGetValue(testScript, out LogFile logFile)) return false;

			logging = logFile;
			return true;
		}

		private void RegisterLogFile(string testScript, DateTime start, DateTime end)
		{
			string logFilePath = String.Empty;
			DateTime creationTime = start;
			string logging = String.Empty;
			string errorReason = String.Empty;

			string outputFolderPath = Path.Combine(TestOutputDirectory, testScript);
			if (!Directory.Exists(outputFolderPath))
			{
				errorReason = $"No test output directory found, expected location: {outputFolderPath}";
				ReportProgress(errorReason);

				logFiles.Add(testScript, new LogFile
				{
					CreationTime = start,
					Path = logFilePath,
					Content = logging,
					ErrorReason = errorReason
				});

				return;
			}

			foreach (string filePath in Directory.EnumerateFiles(outputFolderPath))
			{
				creationTime = File.GetCreationTime(filePath);
				if (start <= creationTime && creationTime <= end)
				{
					logFilePath = filePath;
					break;
				}
			}

			if (String.IsNullOrEmpty(logFilePath))
			{
				errorReason = $"No log file found in directory {outputFolderPath} that was created between {start} and {end}";
				ReportProgress(errorReason);

				logFiles.Add(testScript, new LogFile
				{
					CreationTime = start,
					Path = logFilePath,
					Content = logging,
					ErrorReason = errorReason
				});

				return;
			}

			try
			{
				using (FileStream fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					StreamReader streamReader = new StreamReader(fileStream);
					while (!streamReader.EndOfStream) logging = streamReader.ReadToEnd();
				}
			}
			catch (Exception e)
			{
				errorReason = $"Unable to retrieve logging due to {e}";
				ReportProgress(errorReason);

				logFiles.Add(testScript, new LogFile
				{
					CreationTime = start,
					Path = logFilePath,
					Content = logging,
					ErrorReason = errorReason
				});

				return;
			}

			logFiles.Add(testScript, new LogFile
			{
				CreationTime = creationTime,
				Path = logFilePath,
				Content = logging,
				ErrorReason = errorReason
			});

			ReportProgress($"Found log file: {logFilePath}");
		}

		private void ReportProgress(string progress)
		{
			if (ProgressReported == null) return;
			ProgressReported(this, new ProgressEventArgs(progress));
		}

		public event EventHandler<ProgressEventArgs> ProgressReported;
	}
}
