namespace RegressionTestRunner.Helpers
{
	using System;

	public class ProgressEventArgs : EventArgs
	{
		public ProgressEventArgs(string progress)
		{
			Progress = progress;
		}

		public string Progress { get; private set; }
	}
}