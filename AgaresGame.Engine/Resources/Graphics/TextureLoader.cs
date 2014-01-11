namespace AgaresGame.Engine.Resources.Graphics
{
	using System;
	using System.IO;

	using AgaresGame.Engine.Resources.Loaders;

	using SDL2;

	public class TextureLoader : CachedResourceLoader<Texture>
	{
		private readonly IntPtr renderer;

		internal TextureLoader(IntPtr renderer)
		{
			this.renderer = renderer;
		}

		protected override Texture LoadResource(string filename)
		{
			filename = Path.Combine("Content", filename);

			IntPtr texture = SDL_image.IMG_LoadTexture(this.renderer, filename);
			if (texture == IntPtr.Zero)
			{
				throw new Exception(SDL.SDL_GetError());
			}

			return Texture.FromTexture(texture);
		}
	}
}