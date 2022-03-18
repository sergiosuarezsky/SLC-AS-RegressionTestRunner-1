namespace RegressionTestRunner.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;

	public static class CollapseButtonHelpers
	{
		public static CollapseButton SmallCollapseButton()
		{
			return new CollapseButton(false) { CollapseText = "-", ExpandText = "+", Width = 44 };
		}
	}
}
