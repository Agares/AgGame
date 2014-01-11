namespace AgaresGame.Engine.Performance
{
	public class PerformanceCounterResult
	{
		private readonly double delta;

		public PerformanceCounterResult(double delta)
		{
			this.delta = delta;
		}

		public double Delta
		{
			get
			{
				return this.delta;
			}
		}

		public double FramesPerSecond
		{
			get
			{
				return 1.0 / this.delta;
			}
		}
	}
}