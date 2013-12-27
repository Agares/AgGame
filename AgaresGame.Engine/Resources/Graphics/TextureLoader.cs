using System;
using System.IO;
using AgaresGame.Engine.Resources.Loaders;
using SDL2;

namespace AgaresGame.Engine.Resources.Graphics
{
	public class TextureLoader : CachedResourceLoader<Texture>
	{
		private readonly IntPtr _renderer;

		internal TextureLoader(IntPtr renderer)
		{
			_renderer = renderer;
		}

		protected override Texture LoadResource(string filename)
		{
			filename = Path.Combine("Content", filename);

			IntPtr texture = SDL_image.IMG_LoadTexture(_renderer, filename);
			if (texture == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}

			return Texture.FromTexture(texture);
		}
	}
}