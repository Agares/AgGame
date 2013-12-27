using System;
using AgaresGame.Engine.Resources.Graphics;
using AgaresGame.Engine.Resources.Loaders;

namespace AgaresGame.Engine.Resources
{
	public class ResourceManager
	{
		internal ResourceManager(IntPtr renderContext)
		{
			Textures = new TextureLoader(renderContext);
			Fonts = new FontLoader();
		}

		public IResourceLoader<Texture> Textures { get; set; }
		public IResourceLoader<Font> Fonts { get; set; }
	}
}