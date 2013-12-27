using System;
using AgaresGame.Engine.Mathematics;
using SDL2;

namespace AgaresGame.Engine
{
	public class Window : IDisposable
	{
		private const string Title = "AgGame";
		private readonly Rectangle _initialRectangle;
		private IntPtr _windowPointer;

		public Window()
		{
			_initialRectangle = new Rectangle(new Point2(100, 100), new Vector2(640, 480));

			Show();
			CreateContext();
		}

		public RenderContext RenderContext { get; set; }

		public int Width
		{
			get { return _initialRectangle.Size.X; }
		}

		public int Height
		{
			get { return _initialRectangle.Size.Y; }
		}

		public void Dispose()
		{
			RenderContext.Dispose();
			SDL.SDL_DestroyWindow(_windowPointer);
		}

		private void Show()
		{
			_windowPointer = SDL.SDL_CreateWindow(
				Title,
				_initialRectangle.Position.X,
				_initialRectangle.Position.Y,
				_initialRectangle.Size.X,
				_initialRectangle.Size.Y,
				SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
				);

			if (_windowPointer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}

		private void CreateContext()
		{
			RenderContext = new RenderContext(_windowPointer);
		}
	}
}