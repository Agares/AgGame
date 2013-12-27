using System;
using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources;
using SDL2;

namespace AgaresGame.Engine
{
	public class RenderContext : IDisposable
	{
		private readonly IntPtr _windowPointer;
		internal IntPtr Renderer;

		public RenderContext(IntPtr windowPointer)
		{
			_windowPointer = windowPointer;

			PrepareRenderer();
			Resources = new ResourceManager(Renderer);
		}

		public ResourceManager Resources { get; set; }

		public void Dispose()
		{
			SDL.SDL_DestroyRenderer(Renderer);
		}

		private void PrepareRenderer()
		{
			Renderer = SDL.SDL_CreateRenderer(_windowPointer, -1,
				(uint) (SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC));

			if (Renderer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}

		public void Clear()
		{
			SDL.SDL_RenderClear(Renderer);
		}

		public void Present()
		{
			SDL.SDL_RenderPresent(Renderer);
		}

		public void Render(IRenderable objectToRender, Point2 position)
		{
			objectToRender.Render(this, position);
		}
	}
}