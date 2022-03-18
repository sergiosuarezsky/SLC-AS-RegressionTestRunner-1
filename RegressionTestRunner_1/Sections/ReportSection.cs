namespace RegressionTestRunner.Sections
{
	using System;
	using System.Collections.Generic;
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

		private bool wasLoggingRetrieved = false;

		public ReportSection(RegressionTestManager regressionTestManager, string automationScriptName)
		{
			this.regressionTestManager = regressionTestManager;
			this.automationScriptName = automationScriptName;

			Initialize();
			GenerateUi();
		}

		private void Initialize()
		{
			bool wasSuccessful = regressionTestManager.WasTestSuccessful(automationScriptName);
			if (regressionTestManager.TryGetLogFilePath(automationScriptName, out string logFilePath))
			{
				pathLabel.Text = $"Log file: {logFilePath}";
			}
			else
			{
				pathLabel.Text = $"Log file not found";
			}

			title.Text = $"{automationScriptName} - {(wasSuccessful ? "Success" : "Fail")}";

			collapseButton.LinkedWidgets.Add(pathLabel);
			collapseButton.LinkedWidgets.Add(loggingTextBox);
			collapseButton.LinkedWidgets.Add(whiteSpace);
			collapseButton.Pressed += (s, a) => InitializeLogging();
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

		private void InitializeLogging()
		{
			if (wasLoggingRetrieved) return;
			if (!regressionTestManager.TryGetLogging(automationScriptName, out string logging)) return;

			loggingTextBox.Text = logging;
			wasLoggingRetrieved = true;
		}
	}
}
