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

		public string Name { get; }

		public string Path { get; }

		public Dictionary<string, AutomationScript> Scripts { get; } = new Dictionary<string, AutomationScript>();

		public Dictionary<string, AutomationScriptDirectory> Directories { get; } = new Dictionary<string, AutomationScriptDirectory>();

		public IEnumerable<AutomationScript> GetAllAutomationScripts(List<string> directoriesToSkip = null)
		{
			directoriesToSkip = directoriesToSkip ?? new List<string>();

			var automationScripts = new List<AutomationScript>(Scripts.Values);

			var directoriesToCheck = Directories.Values.Where(d => !directoriesToSkip.Contains(d.Path)).ToList();

			foreach (var directory in directoriesToCheck)
			{
				automationScripts.AddRange(directory.GetAllAutomationScripts(directoriesToSkip));
			}

			return automationScripts;
		}

		public override string ToString()
		{
			return Path;
		}
	}
}
