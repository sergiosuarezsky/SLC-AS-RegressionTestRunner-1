namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
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
		private readonly string[] testScripts = new string[0];
		private readonly List<RegressionTestResult> testResults = new List<RegressionTestResult>();

		private IDmsTable regressionTestResultCollectorResultsTable;

		public RegressionTestManager(IEngine engine, params string[] testScripts)
		{
			this.engine = engine;
			this.testScripts = testScripts;

			InitRegressionTestElement();
		}

		public IEnumerable<string> Scripts => testScripts;

		public IEnumerable<RegressionTestResult> Results => testResults;

		private void InitRegressionTestElement()
		{
			try
			{
				var rawElement = engine.FindElementsByProtocol(RegressionTestProtocolName).FirstOrDefault();
				if (rawElement == null) return;

				var dms = engine.GetDms();
				var element = dms.GetElement(rawElement.ElementName);
				regressionTestResultCollectorResultsTable = element.GetTable(RegressionTestResultsTablePid);
			}
			catch (Exception e)
			{
				engine.Log(nameof(RegressionTestManager), nameof(InitRegressionTestElement), $"Unable to initialize the Regression Test Result Collector element due to {e}");
			}
		}

		public void Run()
		{
			testResults.Clear();
			foreach (string testScript in testScripts)
			{
				ReportProgress($"Executing test {testScript}...");

				RegressionTestResult testResult;
				try
				{
					var subscript = engine.PrepareSubScript(testScript);
					subscript.Synchronous = true;
					subscript.PerformChecks = false;
					subscript.StartScript();

					var scriptResults = subscript.GetScriptResult();
					testResult = new RegressionTestResult(testScript, scriptResults);
				}
				catch (Exception e)
				{
					testResult = new RegressionTestResult(testScript)
					{
						Success = false,
						Reason = e.ToString(),
					};

					ReportProgress($"Something when wrong when running test {testScript} {e}");
				}

				ReportProgress($"Test {(testResult.Success ? "succeeded" : "failed")}");

				testResults.Add(testResult);
			}
		}

		public void PushResultsToCollectorElement()
		{
			if (regressionTestResultCollectorResultsTable == null)
			{
				ReportProgress($"Unable to push results to Regression Test Result Collector");
				return;
			}

			ReportProgress($"Pushing results to Regression Test Result Collector...");

			foreach (var result in testResults)
			{
				if (regressionTestResultCollectorResultsTable.RowExists(result.Script))
				{
					regressionTestResultCollectorResultsTable.SetRow(result.Script, result.ToObjectRow());
				}
				else
				{
					regressionTestResultCollectorResultsTable.AddRow(result.ToObjectRow());
				}
			}

			ReportProgress($"Finished pushing results");
		}

		public void SendResultsByMail(IEnumerable<string> emailAddresses)
		{
			if (!emailAddresses.Any()) return;

			ReportProgress($"Sending results through mail...");

			foreach (string emailAddress in emailAddresses)
			{
				engine.SendEmail(new EmailOptions
				{
					Title = $"Regression Test Results [{DateTime.Now}]",
					TO = emailAddress,
					Message = String.Join(Environment.NewLine, testResults.Select(x => x.ToString()))
				});
			}

			ReportProgress($"Finished sending results");
		}

		private void ReportProgress(string progress)
		{
			ProgressReported?.Invoke(this, new ProgressEventArgs(progress));
		}

		public event EventHandler<ProgressEventArgs> ProgressReported;
	}
}
