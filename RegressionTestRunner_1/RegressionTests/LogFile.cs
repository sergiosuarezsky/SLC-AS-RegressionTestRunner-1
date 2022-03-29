namespace RegressionTestRunner.RegressionTests
{
	using System;
	using System.Text.RegularExpressions;
	using Newtonsoft.Json;
	using RegressionTestRunner.RegressionTests;

	public class LogFile
	{
		public DateTime CreationTime { get; set; }

		public string Path { get; set; }

		public string Content { get; set; }

		public string ErrorReason { get; set; }

		public string Reason
		{
			get
			{
				return GetReason();
			}
		}

		public RegressionTestStates State
		{
			get
			{
				if (String.IsNullOrWhiteSpace(Content)) return RegressionTestStates.Unknown;
				if (Content.Contains("RT_PORTAL_FAIL")) return RegressionTestStates.Fail;
				return RegressionTestStates.OK;
			}
		}

		private string GetReason()
		{
			string[] logLines = Content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (string line in logLines)
			{
				if (Regex.Matches(line, @"Posting to '.*' with body: ").Count <= 0) continue;

				int startIndex = line.IndexOf('{');
				int length = line.LastIndexOf('}') - startIndex + 1;

				try
				{
					string serializedPost = line.Substring(startIndex, length);
					var postBody = JsonConvert.DeserializeObject<PostBody>(serializedPost);
					return postBody.Value;
				}
				catch (Exception e)
				{
					ErrorReason = $"Unable to deserialize the post message on line: {line} due to {e}";
				}
			}

			return ErrorReason;
		}
	}
}
