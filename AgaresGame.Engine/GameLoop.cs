using AgaresGame.Engine.Performance;
using AgaresGame.Engine.Resources;

namespace AgaresGame.Engine
{
	public abstract class GameLoop
	{
		public GameEvents GameEvents { get; private set; }

		protected PerformanceCounterResult LastRenderTime;
		protected bool Quit;
		protected RenderContext RenderContext;

		private readonly Window _window;


		protected GameLoop(Window window)
		{
			_window = window;

			Quit = false;
			GameEvents = new GameEvents();
			GameEvents.Quit += (sender, args) => Quit = true;
		}

		public void Run()
		{
			LoadResources(_window.RenderContext.Resources);
			RenderContext = _window.RenderContext;
			var performanceCounterResult = new PerformanceCounterResult(0);

			while (!Quit)
			{
				GameEvents.HandleEvents();

				var counter = new PerformanceCounter();
				ExecuteLoopBody(performanceCounterResult);
				performanceCounterResult = counter.EndFrame();
			}
		}

		private void ExecuteLoopBody(PerformanceCounterResult lastRenderTime)
		{
			LastRenderTime = lastRenderTime;
			GameEvents.HandleEvents();
			RenderFrame();
		}

		protected abstract void RenderFrame();
		protected abstract void LoadResources(ResourceManager resourceManager);
	}
}