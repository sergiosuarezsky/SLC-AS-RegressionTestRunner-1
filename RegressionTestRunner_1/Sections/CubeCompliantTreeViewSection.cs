using System.Collections.Generic;
using System.Linq;
using RegressionTestRunner.Helpers;
using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;
using Skyline.DataMiner.Net.AutomationUI.Objects;

namespace RegressionTestRunner.Sections
{
	public class CubeCompliantTreeViewSection : Section
	{
		private readonly IEnumerable<TreeViewItem> rootItems;
		private readonly List<CollapseButton> collapseButtons = new List<CollapseButton>();

		private readonly Dictionary<string, CheckBox> itemCheckBoxMapping = new Dictionary<string, CheckBox>();
		private readonly Dictionary<CheckBox, TreeViewItem> checkBoxItemMapping = new Dictionary<CheckBox, TreeViewItem>();

		public CubeCompliantTreeViewSection(IEnumerable<TreeViewItem> treeViewItems)
		{
			rootItems = treeViewItems;
			GenerateUi();
		}

		public IEnumerable<TreeViewItem> Items
		{
			get
			{
				return rootItems;
			}
		}

		public IEnumerable<TreeViewItem> AllItems
		{
			get
			{
				return checkBoxItemMapping.Values;
			}
		}

		public IEnumerable<TreeViewItem> CheckedItems
		{
			get
			{
				return AllItems.Where(x => x.IsChecked);
			}
		}

		public IEnumerable<TreeViewItem> CheckedNodes
		{
			get
			{
				return CheckedItems.Where(x => x.ChildItems.Any());
			}
		}

		public IEnumerable<TreeViewItem> CheckedLeaves
		{
			get
			{
				return CheckedItems.Where(x => !x.ChildItems.Any());
			}
		}

		public int Depth { get; private set; } = 0;

		public void Collapse()
		{
			foreach (var collapseButton in collapseButtons) collapseButton.Collapse();
		}

		public void Expand()
		{
			foreach (var collapseButton in collapseButtons) collapseButton.Expand();
		}

		private void GenerateUi()
		{
			int row = -1;
			foreach (var item in rootItems)
			{
				AddItems(item, null, ref row, -1);
			}
		}

		private void AddItems(TreeViewItem item, CollapseButton parentCollapseButton, ref int row, int column)
		{
			int depth = column + 1;
			if (depth > Depth) Depth = depth;

			Widget widget;
			switch (item.ItemType)
			{
				case TreeViewItem.TreeViewItemType.CheckBox:
					CheckBox checkBox = new CheckBox(item.DisplayValue) { IsChecked = item.IsChecked };

					checkBoxItemMapping.Add(checkBox, item);
					itemCheckBoxMapping.Add(item.KeyValue, checkBox);

					checkBox.Changed += ItemCheckBox_Changed;
					widget = checkBox;
					break;
				case TreeViewItem.TreeViewItemType.Empty:
					widget = new Label(item.DisplayValue);
					break;
				default:
					// Unhandled type
					return;
			}

			++row;
			CollapseButton collapseButton = null;
			if (item.ChildItems.Any())
			{
				collapseButton = CollapseButtonHelpers.SmallCollapseButton();
				collapseButtons.Add(collapseButton);

				AddWidget(collapseButton, row, ++column);
				if (parentCollapseButton != null) parentCollapseButton.LinkedWidgets.Add(collapseButton);
			}

			AddWidget(widget, row, ++column, 1, 10);
			if (parentCollapseButton != null) parentCollapseButton.LinkedWidgets.Add(widget);

			foreach (var child in item.ChildItems)
			{
				AddItems(child, collapseButton, ref row, column);
			}
		}

		private void ItemCheckBox_Changed(object sender, CheckBox.CheckBoxChangedEventArgs e)
		{
			if (!(sender is CheckBox changedCheckBox)) return;
			if (!checkBoxItemMapping.TryGetValue(changedCheckBox, out TreeViewItem item)) return;

			item.IsChecked = e.IsChecked;

			if (e.IsChecked)
			{
				CheckParents(item);
				CheckChildren(item);
			}
			else
			{
				UncheckParents(item);
				UncheckChildren(item);
			}
		}

		private void UncheckParents(TreeViewItem item)
		{
			TreeViewItem parentItem = AllItems.FirstOrDefault(x => x.ChildItems.Any(y => y.KeyValue.Equals(item.KeyValue)));
			List<TreeViewItem> itemsToUncheck = new List<TreeViewItem>();
			while (parentItem != null)
			{
				itemsToUncheck.Add(parentItem);
				parentItem = AllItems.FirstOrDefault(x => x.ChildItems.Any(y => y.KeyValue.Equals(parentItem.KeyValue)));
			}

			foreach (var itemToUncheck in itemsToUncheck)
			{
				itemToUncheck.IsChecked = false;
				itemCheckBoxMapping[itemToUncheck.KeyValue].IsChecked = false;
			}
		}

		private void CheckParents(TreeViewItem item)
		{
			TreeViewItem parentItem = item;
			do
			{
				parentItem = AllItems.FirstOrDefault(x => x.ChildItems.Any(y => y.KeyValue.Equals(parentItem.KeyValue)) && x.ChildItems.All(y => y.IsChecked));
				if (parentItem != null)
				{
					parentItem.IsChecked = true;
					itemCheckBoxMapping[parentItem.KeyValue].IsChecked = true;
				}
			}
			while (parentItem != null);
		}

		private void UncheckChildren(params TreeViewItem[] items)
		{
			foreach (var item in items)
			{
				foreach (var childItem in item.ChildItems)
				{
					childItem.IsChecked = false;
					itemCheckBoxMapping[childItem.KeyValue].IsChecked = false;
				}

				UncheckChildren(item.ChildItems.ToArray());
			}
		}

		private void CheckChildren(params TreeViewItem[] items)
		{
			foreach (var item in items)
			{
				foreach (var childItem in item.ChildItems)
				{
					childItem.IsChecked = true;
					itemCheckBoxMapping[childItem.KeyValue].IsChecked = true;
				}

				CheckChildren(item.ChildItems.ToArray());
			}
		}
	}
}