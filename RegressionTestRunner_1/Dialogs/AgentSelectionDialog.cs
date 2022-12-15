namespace RegressionTestRunner.Dialogs
{
	using System.Collections.Generic;
	using System.Linq;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;
	using Skyline.DataMiner.Library.Common;

	public class AgentSelectionDialog : Dialog
	{
		private readonly Dictionary<string, IDma> agents = new Dictionary<string, IDma>();

		private readonly Label selectAgentsLabel = new Label("Select the agent on which the tests should run");
		private readonly Label agentLabel = new Label("DMA:");
		private readonly DropDown agentsDropDown = new DropDown();

		public AgentSelectionDialog(IEngine engine, IEnumerable<IDma> agents) : base(engine)
		{
			foreach (var agent in agents) this.agents.Add(agent.GetDisplayName(), agent);

			Initialize();
			GenerateUi();
		}

		private void Initialize()
		{
			Title = "Select Agent";

			agentsDropDown.Options = agents.Keys;

			int currentAgentId = Skyline.DataMiner.Automation.Engine.SLNetRaw.ServerDetails.AgentID;
			var currentDma = agents.Values.FirstOrDefault(x => x.Id == currentAgentId);

			if (currentDma != null) agentsDropDown.Selected = currentDma.GetDisplayName();
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			AddWidget(selectAgentsLabel, ++row, 0, 1, 2);

			AddWidget(agentLabel, ++row, 0);
			AddWidget(agentsDropDown, row, 1);

			AddWidget(new WhiteSpace(), ++row, 0, 1, 2);

			AddWidget(RunTestsButton, ++row, 0, 1, 2);

			AddWidget(BackButton, row + 1, 0, 1, 2);
		}

		public IDma SelectedAgent { get { return agents[agentsDropDown.Selected]; } }

		public Button BackButton { get; private set; } = new Button("Back...");

		public Button RunTestsButton { get; private set; } = new Button("Run Tests");
	}
}
