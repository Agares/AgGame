using SDL2;

namespace AgaresGame.Engine.Performance
{
	public class PerformanceCounter
	{
		private readonly uint _startTicks;
		private uint _endTicks;

		public PerformanceCounter()
		{
			_startTicks = SDL.SDL_GetTicks();
		}

		public PerformanceCounterResult EndFrame()
		{
			_endTicks = SDL.SDL_GetTicks();
			return new PerformanceCounterResult(((double) _endTicks - _startTicks)/1000.0);
		}
	}
}