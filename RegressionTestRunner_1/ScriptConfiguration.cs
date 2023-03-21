namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;

	internal class ScriptConfiguration
	{
		/// <summary>
		/// Folders from the Automation module that will be checked for automation scripts to run.
		/// </summary>
		public List<string> Folders { get; set; } = new List<string>();

		/// <summary>
		/// Scripts that will be executed by this script regardless of location.
		/// </summary>
		public List<string> Scripts { get; set; } = new List<string>();

		/// <summary>
		/// Folders from the Automation module that will be skipped when looking for script to execute.
		/// </summary>
		public List<string> FoldersToSkip { get; set; } = new List<string>();

		/// <summary>
		/// Scripts that won't be executed by this script.
		/// </summary>
		public List<string> ScriptsToSkip { get; set; } = new List<string>();

		/// <summary>
		/// List of email address to which a report will be sent after the tests have run.
		/// </summary>
		public List<string> Recipients { get; set; } = new List<string>();

		/// <summary>
		/// Flag that indicates whether subdirectories should be checked or not.
		/// </summary>
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
