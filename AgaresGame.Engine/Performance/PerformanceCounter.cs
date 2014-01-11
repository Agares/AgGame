namespace AgaresGame.Engine.Performance
{
	using SDL2;

	public class PerformanceCounter
	{
		private readonly uint startTicks;

		private uint endTicks;

		public PerformanceCounter()
		{
			this.startTicks = SDL.SDL_GetTicks();
		}

		public PerformanceCounterResult EndFrame()
		{
			this.endTicks = SDL.SDL_GetTicks();
			return new PerformanceCounterResult(((double)this.endTicks - this.startTicks) / 1000.0);
		}
	}
}