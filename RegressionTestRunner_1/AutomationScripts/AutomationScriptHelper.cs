namespace RegressionTestRunner.AutomationScripts
{
	using System;
	using System.Linq;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Net.Messages.Advanced;

	public static class AutomationScriptHelper
	{
		public static AutomationScriptDirectory RetrieveScripts(IEngine engine, string directoryName)
		{
			AutomationScriptDirectory rootDirectory = new AutomationScriptDirectory(directoryName, String.Empty);
			var response = engine.SendSLNetSingleResponseMessage(new GetAutomationInfoMessage(21, String.Empty)) as GetAutomationInfoResponseMessage;
			if (response == null) return rootDirectory;
			if (response.psaRet == null || response.psaRet.Psa == null || !response.psaRet.Psa.Any()) return rootDirectory;

			foreach (string[] sa in response.psaRet.Psa.Select(x => x.Sa))
			{
				if (!sa.Any()) continue;

				string fullPath = sa.First();
				if (!TryCreateDirectory(rootDirectory, fullPath, out AutomationScriptDirectory directory)) continue;

				foreach (string scriptName in sa.Skip(1))
				{
					if (directory.Scripts.ContainsKey(scriptName)) continue;

					directory.Scripts.Add(scriptName, new AutomationScript
					{
						Name = scriptName,
						Path = fullPath
					});
				}
			}

			return rootDirectory;
		}

		private static bool TryCreateDirectory(AutomationScriptDirectory rootDirectory, string path, out AutomationScriptDirectory directory)
		{
			directory = null;

			string[] splitPath = path.Split('/', '\\');
			if (!splitPath.First().Equals(rootDirectory.Name)) return false;

			directory = rootDirectory;
			foreach (string subPath in splitPath.Skip(1))
			{
				if (!directory.Directories.TryGetValue(subPath, out AutomationScriptDirectory childDirectory))
				{
					AutomationScriptDirectory newChildDirectory = new AutomationScriptDirectory(subPath, directory.ToString());
					directory.Directories.Add(subPath, newChildDirectory);
					directory = newChildDirectory;
				}
				else
				{
					directory = childDirectory;
				}
			}

			return true;
		}
	}
}
