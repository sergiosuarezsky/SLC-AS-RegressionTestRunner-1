namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using RegressionTestRunner.AutomationScripts;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.Automation;

	public class RegressionTestManager
	{
		private const string TestOutputDirectory = @"C:\RTManager\TestOutput";

		private readonly IEngine engine;
		private readonly string[] testScripts;
		private readonly Dictionary<string, string> logFilePaths = new Dictionary<string, string>();
		private readonly Dictionary<string, bool> runStates = new Dictionary<string, bool>();

		public RegressionTestManager(IEngine engine, params string[] testScripts)
		{
			this.engine = engine;
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
					SubScriptOptions subscriptInfo = engine.PrepareSubScript(testScript);
					subscriptInfo.Synchronous = true;
					subscriptInfo.StartScript();
					runStates.Add(testScript, true);
				}
				catch (Exception e)
				{
					ReportProgress($"Something when wrong when running test {testScript} {e}");
					runStates.Add(testScript, false);
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

		public bool WasTestSuccessful(string testScript)
		{
			if (!runStates.TryGetValue(testScript, out bool state)) return false;
			return state;
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
