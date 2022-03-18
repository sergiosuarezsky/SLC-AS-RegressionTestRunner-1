namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using RegressionTestRunner.AutomationScripts;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Library.Common;
	using Skyline.DataMiner.Net.Messages;

	public class RegressionTestManager
	{
		public static readonly string TestOutputDirectory = @"C:\RTManager\TestOutput";

		private readonly IEngine engine;
		private readonly IDma agent;
		private readonly string[] testScripts;
		private readonly Dictionary<string, string> logFilePaths = new Dictionary<string, string>();

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
							"DEFER:FALSE" // async execution
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

		public bool WasTestSuccessful(string automationScript)
		{
			if (!TryGetLogging(automationScript, out string logging)) return false;
			return !logging.Contains("RT_PORTAL_FAIL");
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
			foreach (string filePath in Directory.EnumerateFiles(outputFolderPath))
			{
				DateTime creationTime = File.GetCreationTime(filePath);
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
}
