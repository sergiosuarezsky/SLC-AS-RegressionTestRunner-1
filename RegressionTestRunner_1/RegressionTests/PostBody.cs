namespace RegressionTestRunner.RegressionTests
{
	using System;

	internal class PostBody
	{
		public string AgentName { get; set; }

		public DateTime Date { get; set; }

		public bool Failure { get; set; }

		public string Source { get; set; }

		public DateTime StartTime { get; set; }

		public Test Test { get; set; }

		public TestCase TestCase { get; set; }

		public string TestExecutionId { get; set; }

		public string Value { get; set; }

		public string Version { get; set; }
	}
}
