namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Library.Automation;

	public class RegressionTestReport
	{
		private readonly string agentName;
		private readonly IEnumerable<RegressionTestResult> results;
		private readonly DateTime creationTime = DateTime.Now;

		public RegressionTestReport(IEngine engine, IEnumerable<RegressionTestResult> results)
		{
			if (engine == null) throw new ArgumentNullException(nameof(engine));
			this.results = results ?? throw new ArgumentNullException(nameof(results));

			var dms = engine.GetDms();
			var agent = dms.GetAgent(Engine.SLNetRaw.ServerDetails.AgentID);
			agentName = agent.Name;
		}

		public string Title
		{
			get
			{
				return $"Regression Test Results - {agentName} [{creationTime}]";
			}
		}

		public string Body
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("<table style=\"width:100%\">");

				// Add header
				sb.Append("<tr>");
				sb.Append("<th>Test</th>");
				sb.Append("<th>Time</th>");
				sb.Append("<th>State</th>");
				sb.Append("<th>Reason</th>");
				sb.Append("</tr>");

				// Add results
				foreach (var result in results)
				{
					sb.Append("<tr>");
					sb.Append($"<td>{result.Script}</td>");
					sb.Append($"<td>{result.CreationTime}</td>");
					sb.Append($"<td style=\"color:white;{(result.Success ? "background:green" : "background:red")}\">{(result.Success ? "OK" : "Fail" )}</td>");
					sb.Append($"<td>{result.Reason}</td>");
					sb.Append("</tr>");
				}

				sb.Append("</table>");

				return sb.ToString();
			}
		}
	}
}
