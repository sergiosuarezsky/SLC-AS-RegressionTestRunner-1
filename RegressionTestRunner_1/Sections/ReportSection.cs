namespace RegressionTestRunner.Sections
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;

	public class ReportSection : Section
	{
		private readonly RegressionTestManager regressionTestManager;
		private readonly string automationScriptName;

		private readonly CollapseButton collapseButton = CollapseButtonHelpers.SmallCollapseButton();
		private readonly Label title = new Label { Style = TextStyle.Heading };
		private readonly Label pathLabel = new Label(String.Empty);
		private readonly TextBox loggingTextBox = new TextBox { Height = 500, Width = 800, IsMultiline = true };
		private readonly WhiteSpace whiteSpace = new WhiteSpace();

		public ReportSection(RegressionTestManager regressionTestManager, string automationScriptName)
		{
			this.regressionTestManager = regressionTestManager;
			this.automationScriptName = automationScriptName;

			Initialize();
			GenerateUi();
		}

		private void Initialize()
		{
			string status;
			if (regressionTestManager.TryGetLogFilePath(automationScriptName, out string logFilePath))
			{
				pathLabel.Text = $"Log file: {logFilePath}";

				regressionTestManager.TryGetLogging(automationScriptName, out string logging);
				loggingTextBox.Text = logging;

				bool success = regressionTestManager.WasTestSuccessful(automationScriptName);
				status = success ? "Success" : "Fail";
			}
			else
			{
				logFilePath = Path.Combine(RegressionTestManager.TestOutputDirectory, automationScriptName);

				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Log file not found");
				sb.AppendLine("This could be because the RT ran on an agent different than the one you are connected with.");
				sb.AppendLine($"The logging should be available in {logFilePath}");

				pathLabel.Text = sb.ToString();
				status = "Unknown";
			}
			
			title.Text = $"{automationScriptName} - {status}";

			collapseButton.LinkedWidgets.Add(pathLabel);
			collapseButton.LinkedWidgets.Add(loggingTextBox);
			collapseButton.LinkedWidgets.Add(whiteSpace);
			collapseButton.Collapse();
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			AddWidget(collapseButton, ++row, 0);
			AddWidget(title, row, 1);

			AddWidget(pathLabel, ++row, 1);

			AddWidget(loggingTextBox, ++row, 1);

			AddWidget(whiteSpace, ++row, 0, 1, 2);
		}
	}
}
