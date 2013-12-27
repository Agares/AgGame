using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Performance;
using AgaresGame.Engine.Resources;
using SDL2;

namespace AgaresGame.Engine
{
	public abstract class GameLoop
	{
		private readonly KeyboardTranslator _keyboardTranslator;
		private readonly Window _window;

		protected PerformanceCounterResult LastRenderTime;
		protected bool Quit;
		protected RenderContext RenderContext;


		protected GameLoop(Window window)
		{
			_window = window;
			_keyboardTranslator = new KeyboardTranslator();

			Quit = false;
		}

		internal void CallOnQuit()
		{
			Quit = true;
			OnQuit();
		}

		public void Run()
		{
			LoadResources(_window.RenderContext.Resources);
			RenderContext = _window.RenderContext;
			var performanceCounterResult = new PerformanceCounterResult(0);

			while (!Quit)
			{
				var counter = new PerformanceCounter();
				ExecuteLoopBody(performanceCounterResult);
				performanceCounterResult = counter.EndFrame();
			}
		}

		private void ExecuteLoopBody(PerformanceCounterResult lastRenderTime)
		{
			LastRenderTime = lastRenderTime;
			HandleEvents();
			RenderFrame();
		}

		private void HandleEvents()
		{
			SDL.SDL_Event ev;
			while (SDL.SDL_PollEvent(out ev) > 0)
			{
				if (ev.type == SDL.SDL_EventType.SDL_QUIT)
				{
					CallOnQuit();
				}
				else if (ev.type == SDL.SDL_EventType.SDL_MOUSEMOTION)
				{
					OnMouseMove(new Point2(ev.motion.x, ev.motion.y));
				}
				else if (ev.type == SDL.SDL_EventType.SDL_KEYDOWN)
				{
					OnKeyDown(_keyboardTranslator.TranslateKey(ev.key.keysym.sym),
						_keyboardTranslator.TranslateModifier(ev.key.keysym.mod));
				}
			}
		}

		protected abstract void RenderFrame();
		protected abstract void LoadResources(ResourceManager resourceManager);

		protected abstract void OnQuit();
		protected abstract void OnKeyDown(Keys key, Modifiers modifier);
		protected abstract void OnMouseMove(Point2 point);
	}
}