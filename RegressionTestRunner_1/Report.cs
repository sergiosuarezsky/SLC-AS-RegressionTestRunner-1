namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class Report
	{
		public Report(string scriptName)
		{
			Script = scriptName;
		}

		public string Script { get; private set; }

		public bool Success { get; set; }

		public string Error { get; set; }
	}
}
