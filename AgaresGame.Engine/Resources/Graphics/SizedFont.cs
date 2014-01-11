namespace AgaresGame.Engine.Resources.Graphics
{
	using System;
	using System.Runtime.InteropServices;

	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Utils;

	using SDL2;

	internal class SizedFont
	{
		private readonly IntPtr pointer;

		public SizedFont(string filename, int size)
		{
			this.pointer = SDL_ttf.TTF_OpenFont(filename, size);
			if (this.pointer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}

		public Vector2 ComputeSize(string text)
		{
			IntPtr rendered = this.RenderToSurface(text, new Color(0, 0, 0, 255));
			var surface = (SDL.SDL_Surface)Marshal.PtrToStructure(rendered, typeof(SDL.SDL_Surface));
			SDL.SDL_FreeSurface(rendered);

			return new Vector2(surface.w, surface.h);
		}

		public void Render(RenderContext context, string text, Point2 destination, Color color)
		{
			IntPtr surface = this.RenderToSurface(text, color);
			Texture wrappedTexture = Texture.FromSurface(context, surface);
			SDL.SDL_FreeSurface(surface);

			wrappedTexture.RenderWhole(context, destination);
		}

		private IntPtr RenderToSurface(string text, Color color)
		{
			IntPtr rendered = SDL_ttf.TTF_RenderUNICODE_Blended(this.pointer, text, SdlColorUtils.FromColor(color));
			if (rendered == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}

			return rendered;
		}
	}
}