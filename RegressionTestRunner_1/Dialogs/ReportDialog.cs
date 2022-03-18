namespace RegressionTestRunner.Dialogs
{
	using System.Collections.Generic;
	using RegressionTestRunner.Sections;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;

	public class ReportDialog : Dialog
	{
		private readonly RegressionTestManager regressionTestManager;
		private readonly List<ReportSection> reportSections = new List<ReportSection>();

		public ReportDialog(IEngine engine, RegressionTestManager regressionTestManager) : base(engine)
		{
			this.regressionTestManager = regressionTestManager;

			Initialize();
			GenerateUi();
		}

		private void Initialize()
		{
			Title = "Regression Test Report";

			foreach (string testScript in regressionTestManager.TestScripts)
			{
				reportSections.Add(new ReportSection(regressionTestManager, testScript));
			}
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			foreach (var section in reportSections)
			{
				AddSection(section, ++row, 0);
				row += section.RowCount;
			}

			AddWidget(PerformAdditionalTestsButton, ++row, 0, 1, 2);
			AddWidget(FinishButton, ++row, 0, 1, 2);

			SetColumnWidth(0, 50);
		}

		public Button PerformAdditionalTestsButton { get; private set; } = new Button("Perform Additional Tests...");

		public Button FinishButton { get; private set; } = new Button("Finish");
	}
}
