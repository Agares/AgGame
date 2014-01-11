namespace AgaresGame.Engine
{
	using AgaresGame.Engine.Performance;
	using AgaresGame.Engine.Resources;

	public abstract class GameLoop
	{
		private readonly Window window;

		protected GameLoop(Window window)
		{
			this.window = window;

			this.Quit = false;
			this.GameEvents = new GameEvents();
			this.GameEvents.Quit += (sender, args) => this.Quit = true;
		}

		public GameEvents GameEvents { get; private set; }

		protected PerformanceCounterResult LastRenderTime { get; set; }

		protected bool Quit { get; set; }

		protected RenderContext RenderContext { get; set; }

		public void Run()
		{
			this.LoadResources(this.window.RenderContext.Resources);
			this.RenderContext = this.window.RenderContext;
			var performanceCounterResult = new PerformanceCounterResult(0);

			while (!this.Quit)
			{
				var counter = new PerformanceCounter();
				this.ExecuteLoopBody(performanceCounterResult);
				performanceCounterResult = counter.EndFrame();
			}
		}

		protected abstract void LoadResources(ResourceManager resourceManager);

		protected abstract void RenderFrame();

		private void ExecuteLoopBody(PerformanceCounterResult lastRenderTime)
		{
			this.LastRenderTime = lastRenderTime;
			this.GameEvents.HandleEvents();
			this.RenderFrame();
		}
	}
}