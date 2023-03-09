namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;

	internal class ScriptConfiguration
	{
		public List<string> Folders { get; set; } = new List<string>();

		public List<string> Scripts { get; set; } = new List<string>();

		public List<string> FoldersToSkip { get; set; } = new List<string>();

		public List<string> ScriptsToSkip { get; set; } = new List<string>();

		public bool SearchSubDirectories { get; set; }

		public static bool TryDeserialize(string serializedConfig, out ScriptConfiguration scriptConfiguration)
		{
			scriptConfiguration = null;
			try
			{
				scriptConfiguration = JsonConvert.DeserializeObject<ScriptConfiguration>(serializedConfig);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
