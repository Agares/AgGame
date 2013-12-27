using System;
using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Utils;
using SDL2;

namespace AgaresGame.Engine.Resources.Graphics
{
	internal class FontWithSize
	{
		private readonly IntPtr _pointer;

		public FontWithSize(string filename, int size)
		{
			_pointer = SDL_ttf.TTF_OpenFont(filename, size);
			if (_pointer == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}

		public void Render(RenderContext context, string text, Point2 destination, Color color)
		{
			IntPtr surface = RenderToSurface(text, color);
			Texture wrappedTexture = Texture.FromSurface(context, surface);
			SDL.SDL_FreeSurface(surface);

			wrappedTexture.RenderWhole(context, destination);
		}

		private IntPtr RenderToSurface(string text, Color color)
		{
			IntPtr rendered = SDL_ttf.TTF_RenderUNICODE_Blended(_pointer, text, SdlColorUtils.FromColor(color));
			if (rendered == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}
			return rendered;
		}
	}
}