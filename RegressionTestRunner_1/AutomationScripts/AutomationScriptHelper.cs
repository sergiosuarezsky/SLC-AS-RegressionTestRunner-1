namespace RegressionTestRunner.AutomationScripts
{
	using System;
	using System.IO;
	using System.Linq;
	using Newtonsoft.Json;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Net.Messages.Advanced;

	public static class AutomationScriptHelper
	{
		public static AutomationScriptDirectory RetrieveScripts(IEngine engine, string directoryPath, bool searchSubDirectories = true)
		{
			AutomationScriptDirectory rootDirectory = new AutomationScriptDirectory(CleanPath(directoryPath));

			var response = engine.SendSLNetSingleResponseMessage(new GetAutomationInfoMessage(21, String.Empty)) as GetAutomationInfoResponseMessage;
			if (response == null) return rootDirectory;
			if (response.psaRet == null || response.psaRet.Psa == null || !response.psaRet.Psa.Any()) return rootDirectory;

			foreach (string[] sa in response.psaRet.Psa.Select(x => x.Sa))
			{
				HandleAutomationScriptResponse(rootDirectory, sa, directoryPath, searchSubDirectories);
			}

			return rootDirectory;
		}

		private static void HandleAutomationScriptResponse(AutomationScriptDirectory rootDirectory, string[] sa, string directoryPath, bool searchSubDirectories)
		{
			if (!sa.Any()) return;

			string fullPath = CleanPath(sa.First());

			if (!searchSubDirectories && !fullPath.Equals(directoryPath)) return;
			if (!TryCreateDirectory(rootDirectory, fullPath, out AutomationScriptDirectory directory)) return;

			foreach (string scriptName in sa.Skip(1))
			{
				if (directory.Scripts.ContainsKey(scriptName)) return;

				directory.Scripts.Add(scriptName, new AutomationScript
				{
					Name = scriptName,
					Path = fullPath
				});
			}
		}

		private static bool TryCreateDirectory(AutomationScriptDirectory rootDirectory, string path, out AutomationScriptDirectory directory)
		{
			directory = null;

			string[] splitPath = path.Split('/');
			string[] splitRootPath = rootDirectory.Path.Split('/');
			if (!splitPath.First().Equals(splitRootPath.First())) return false;

			directory = rootDirectory;
			foreach (string subPath in splitPath.Skip(1))
			{
				if (!directory.Directories.TryGetValue(subPath, out AutomationScriptDirectory childDirectory))
				{
					string childPath = $"{directory.Path}/{subPath}";
					AutomationScriptDirectory newChildDirectory = new AutomationScriptDirectory(childPath);
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

		private static string CleanPath(string path)
		{
			return path.Replace("\\", "/").Trim('/');
		}
	}
}
