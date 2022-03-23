namespace RegressionTestRunner.AutomationScripts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class AutomationScriptDirectory
	{
		public AutomationScriptDirectory(string path)
		{
			Path = path ?? throw new ArgumentException(nameof(path));
			Name = path.Split('/').Last();
		}

		public IEnumerable<AutomationScript> AllAutomationScripts
		{
			get
			{
				List<AutomationScript> automationScripts = new List<AutomationScript>(Scripts.Values);
				foreach (var directory in Directories.Values)
				{
					automationScripts.AddRange(directory.AllAutomationScripts);
				}

				return automationScripts;
			}
		}

		public string Name { get; }

		public string Path { get; }

		public Dictionary<string, AutomationScript> Scripts { get; } = new Dictionary<string, AutomationScript>();

		public Dictionary<string, AutomationScriptDirectory> Directories { get; } = new Dictionary<string, AutomationScriptDirectory>();

		public override string ToString()
		{
			return Path;
		}
	}
}
