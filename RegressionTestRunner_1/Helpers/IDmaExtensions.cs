namespace RegressionTestRunner.Helpers
{
	using Skyline.DataMiner.Library.Common;

	public static class IDmaExtensions
	{
		public static string GetDisplayName(this IDma dma)
		{
			return $"{dma.Name} [{dma.Id}]";
		}
	}
}
