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
		private const string RootDirectoryName = @"RTManager";

		private readonly Label selectTestsLabel = new Label("Select regression tests to run:");

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
				Engine.Log($"Selected Scripts: {String.Join(", ", treeView.CheckedLeaves.Select(x => x.DisplayValue))}");

				return (from automationScript in rootDirectory.AllAutomationScripts
						where treeView.CheckedLeaves.Any(x => x.KeyValue.Equals(automationScript.ToString()))
						select automationScript);
			}
		}

		private void Initialize()
		{
			Title = "Regression Test Runner";
			rootDirectory = AutomationScriptHelper.RetrieveScripts(Engine, RootDirectoryName);
			treeView = new CubeCompliantTreeViewSection(new[] { BuildTree(rootDirectory) });
			treeView.Collapse();
		}

		private void GenerateUi()
		{
			Clear();

			int row = -1;

			AddWidget(selectTestsLabel, ++row, 0, 1, 5);

			AddSection(treeView, new SectionLayout(++row, 0));
			row += treeView.RowCount;

			AddWidget(new WhiteSpace(), ++row, 0, 1, 5);
			AddWidget(RunTestsButton, ++row, 0, 1, 5);

			Engine.Log("ScriptSelectionDialog: " + treeView.Depth);
			for (int i = 0; i < treeView.Depth; i++) SetColumnWidth(i, 50);
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
			foreach (var subDirectory in directory.Directories.Values)
			{
				TreeViewItem directoryItem = new TreeViewItem(subDirectory.Name, subDirectory.ToString()) { ItemType = TreeViewItem.TreeViewItemType.CheckBox };
				directoryItem.ChildItems.AddRange(GenerateChildren(subDirectory));
				items.Add(directoryItem);
			}

			foreach (var script in directory.Scripts.Values)
			{
				items.Add(new TreeViewItem(script.Name, script.ToString()) { ItemType = TreeViewItem.TreeViewItemType.CheckBox });
			}

			return items;
		}

		public Button RunTestsButton { get; private set; } = new Button("Run Tests");
	}
}
