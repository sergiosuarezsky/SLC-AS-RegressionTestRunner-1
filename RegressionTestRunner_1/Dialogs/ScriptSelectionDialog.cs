namespace RegressionTestRunner.Dialogs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using RegressionTestRunner.AutomationScripts;
	using RegressionTestRunner.Sections;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;
	using Skyline.DataMiner.Net.AutomationUI.Objects;
	using Skyline.DataMiner.Net.Messages.Advanced;

	public class ScriptSelectionDialog : Dialog
	{
		private const string RootDirectoryName = @"YLE";

		private readonly Label selectTestsLabel = new Label("Select regression tests to run:");
		private readonly Label noRegressionTestsFoundLabel = new Label("No regression tests found on the DMA");

		private CubeCompliantTreeViewSection treeView;
		private AutomationScriptDirectory rootDirectory;

		public ScriptSelectionDialog(IEngine engine) : base(engine)
		{
			Initialize();
			GenerateUi();
		}

		public IEnumerable<AutomationScript> SelectedScripts
		{
			get
			{
				return (from automationScript in rootDirectory.GetAllAutomationScripts()
						where treeView.CheckedLeaves.Any(x => x.KeyValue.Equals(automationScript.ToString()))
						select automationScript);
			}
		}

		private void Initialize()
		{
			Title = "Select Tests";
			rootDirectory = AutomationScriptHelper.RetrieveScripts(Engine, RootDirectoryName);
			treeView = new CubeCompliantTreeViewSection(new[] { BuildTree(rootDirectory) });
			treeView.Collapse();
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			if (rootDirectory.GetAllAutomationScripts().Any())
			{
				AddWidget(selectTestsLabel, ++row, 0, 1, 5);

				AddSection(treeView, new SectionLayout(++row, 0));
				row += treeView.RowCount;

				AddWidget(new WhiteSpace(), ++row, 0, 1, 5);
				AddWidget(SelectAgentButton, ++row, 0, 1, 5);

				for (int i = 0; i < treeView.Depth; i++) SetColumnWidth(i, 50);
			}
			else
			{
				AddWidget(noRegressionTestsFoundLabel, ++row, 0);

				AddWidget(OkButton, ++row, 0);
			}
		}

		private TreeViewItem BuildTree(AutomationScriptDirectory directory)
		{
			TreeViewItem rootItem = new TreeViewItem(directory.Name, directory.ToString()) { ItemType = TreeViewItem.TreeViewItemType.CheckBox };
			rootItem.ChildItems.AddRange(GenerateChildren(directory));

			return rootItem;
		}

		private IEnumerable<TreeViewItem> GenerateChildren(AutomationScriptDirectory directory)
		{
			List<TreeViewItem> items = new List<TreeViewItem>();
			foreach (var subDirectory in directory.Directories.Values.OrderBy(x => x.Name))
			{
				TreeViewItem directoryItem = new TreeViewItem(subDirectory.Name, subDirectory.ToString()) { ItemType = TreeViewItem.TreeViewItemType.CheckBox };
				directoryItem.ChildItems.AddRange(GenerateChildren(subDirectory));
				items.Add(directoryItem);
			}

			foreach (var script in directory.Scripts.Values.OrderBy(x => x.Name))
			{
				items.Add(new TreeViewItem(script.Name, script.ToString()) { ItemType = TreeViewItem.TreeViewItemType.CheckBox });
			}

			return items;
		}

		public Button SelectAgentButton { get; private set; } = new Button("Run Tests...");

		public Button OkButton { get; private set; } = new Button("OK");
	}
}
