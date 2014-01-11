namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources;

	using SDL2;

	public class RenderContext : IDisposable
	{
		private readonly IntPtr windowPointer;

		public RenderContext(IntPtr windowPointer)
		{
			this.windowPointer = windowPointer;

			this.PrepareRenderer();
			this.Resources = new ResourceManager(this.Renderer);
		}

		public ResourceManager Resources { get; set; }

		internal IntPtr Renderer { get; set; }

		public void Dispose()
		{
			SDL.SDL_DestroyRenderer(this.Renderer);
		}

		public void Clear()
		{
			SDL.SDL_RenderClear(this.Renderer);
		}

		public void Present()
		{
			SDL.SDL_RenderPresent(this.Renderer);
		}

		public void Render(IRenderable objectToRender, Point2 position)
		{
			objectToRender.Render(this, position);
		}

		private void PrepareRenderer()
		{
			this.Renderer = SDL.SDL_CreateRenderer(
				this.windowPointer, 
				-1, 
				(uint)(SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC));

			if (this.Renderer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}
	}
}