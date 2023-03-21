namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;

	public class RegressionTestResult
	{
		public const string SuccessKey = "Success";
		public const string ReasonKey = "Reason";

		public RegressionTestResult(string script)
		{
			if (String.IsNullOrWhiteSpace(script)) throw new NotSupportedException();
			Script = script;
		}

		public RegressionTestResult(string script, IReadOnlyDictionary<string, string> results) : this(script)
		{
			if (results.TryGetValue(SuccessKey, out string success)) Success = bool.Parse(success);
			if (results.TryGetValue(ReasonKey, out string error)) Reason = error;
		}

		public Dictionary<string, string> Results
		{
			get
			{
				return new Dictionary<string, string>
				{
					{ SuccessKey, Success.ToString() },
					{ ReasonKey, Reason },
				};
			}
		}

		public string Script { get; private set; }

		public bool Success { get; set; } = true;

		public string Reason { get; set; } = String.Empty;

		public DateTime CreationTime { get; } = DateTime.Now;

		public object[] ToObjectRow()
		{
			return new object[]
			{
				Script,
				Convert.ToInt32(Success),
				Reason,
				CreationTime.ToOADate()
			};
		}

		public override string ToString()
		{
			return String.Join("\t", new string[]
			{
				Script,
				Success.ToString(),
				Reason
			});
		}
	}
}
