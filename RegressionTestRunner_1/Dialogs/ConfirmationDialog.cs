namespace RegressionTestRunner.Dialogs
{
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;

	public class ConfirmationDialog : Dialog
	{
		private readonly Label messageLabel = new Label();

		public ConfirmationDialog(IEngine engine) : base(engine)
		{
			GenerateUi();
		}

		public Button YesButton { get; private set; } = new Button("Yes");

		public Button NoButton { get; private set; } = new Button("No");

		public string Message
		{
			get
			{
				return messageLabel.Text;
			}

			set
			{
				messageLabel.Text = value;
			}
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			AddWidget(messageLabel, ++row, 0, 1, 2);

			AddWidget(new WhiteSpace(), ++row, 0, 1, 2);

			AddWidget(NoButton, ++row, 0, 1, 1, HorizontalAlignment.Left);
			AddWidget(YesButton, row, 1, 1, 1, HorizontalAlignment.Right);
		}
	}
}
