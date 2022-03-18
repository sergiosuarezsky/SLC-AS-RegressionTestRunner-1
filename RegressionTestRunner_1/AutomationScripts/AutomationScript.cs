namespace RegressionTestRunner.AutomationScripts
{
	using System;

	public class AutomationScript
	{
		public string Name { get; set; }

		public string Path { get; set; }

		public override string ToString()
		{
			return String.Join(System.IO.Path.DirectorySeparatorChar.ToString(), new[] { Path, Name });
		}
	}
}
