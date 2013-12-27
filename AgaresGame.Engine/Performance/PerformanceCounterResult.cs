namespace AgaresGame.Engine.Performance
{
	public class PerformanceCounterResult
	{
		private readonly double _delta;

		public PerformanceCounterResult(double delta)
		{
			_delta = delta;
		}

		public double Delta
		{
			get { return _delta; }
		}

		public double FramesPerSecond
		{
			get { return 1.0/_delta; }
		}
	}
}