namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Mathematics;

	using SDL2;

	public class Window : IDisposable
	{
		private const string Title = "AgGame";

		private readonly Rectangle initialRectangle;

		private IntPtr windowPointer;

		public Window()
		{
			this.initialRectangle = new Rectangle(new Point2(100, 100), new Vector2(640, 480));

			this.Show();
			this.CreateContext();
		}

		public int Height
		{
			get
			{
				return this.initialRectangle.Size.Y;
			}
		}

		public RenderContext RenderContext { get; set; }

		public int Width
		{
			get
			{
				return this.initialRectangle.Size.X;
			}
		}

		public void Dispose()
		{
			this.RenderContext.Dispose();
			SDL.SDL_DestroyWindow(this.windowPointer);
		}

		private void CreateContext()
		{
			this.RenderContext = new RenderContext(this.windowPointer);
		}

		private void Show()
		{
			this.windowPointer = SDL.SDL_CreateWindow(
				Title, 
				this.initialRectangle.Position.X, 
				this.initialRectangle.Position.Y, 
				this.initialRectangle.Size.X, 
				this.initialRectangle.Size.Y, 
				SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

			if (this.windowPointer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}
	}
}