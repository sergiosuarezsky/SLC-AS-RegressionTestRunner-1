namespace RegressionTestRunner.Sections
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using RegressionTestRunner.Helpers;
	using RegressionTestRunner.RegressionTests;
	using Skyline.DataMiner.Utils.InteractiveAutomationScript;

	public class ReportSection : Section
	{
		private readonly CollapseButton collapseButton = CollapseButtonHelpers.SmallCollapseButton();
		private readonly Label titleLabel = new Label { Style = TextStyle.Heading };
		private readonly TextBox reasonTextBox = new TextBox { Height = 200, Width = 800, IsMultiline = true };
		private readonly WhiteSpace whiteSpace = new WhiteSpace();

		private readonly RegressionTestResult result;

		public ReportSection(RegressionTestResult result)
		{
			this.result = result ?? throw new ArgumentNullException(nameof(result));
			Initialize();
			GenerateUi();
		}

		private void Initialize()
		{		
			titleLabel.Text = $"{result.Script} - {(result.Success ? "Success" : "Fail")}";
			reasonTextBox.Text = result.Reason;

			collapseButton.LinkedWidgets.Add(reasonTextBox);
			collapseButton.LinkedWidgets.Add(whiteSpace);
			collapseButton.Collapse();
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			AddWidget(collapseButton, ++row, 0);
			AddWidget(titleLabel, row, 1);

			AddWidget(reasonTextBox, ++row, 1);

			AddWidget(whiteSpace, row + 1, 0, 1, 2);
		}
	}
}
