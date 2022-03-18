namespace RegressionTestRunner.AutomationScripts
{
	using System;
	using System.Collections.Generic;

	public class AutomationScriptDirectory
	{
		public AutomationScriptDirectory(string name)
		{
			Name = name ?? throw new ArgumentException(nameof(name));
		}

		public AutomationScriptDirectory(string name, string path)
		{
			Name = name ?? throw new ArgumentException(nameof(name));
			Path = path ?? throw new ArgumentException(nameof(path));
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
			if (String.IsNullOrEmpty(Path)) return Name;
			return String.Join(System.IO.Path.DirectorySeparatorChar.ToString(), new[] { Path, Name });
		}
	}
}
