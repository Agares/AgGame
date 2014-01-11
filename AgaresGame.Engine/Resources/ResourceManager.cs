namespace AgaresGame.Engine.Resources
{
	using System;

	using AgaresGame.Engine.Resources.Graphics;
	using AgaresGame.Engine.Resources.Loaders;

	public class ResourceManager
	{
		internal ResourceManager(IntPtr renderContext)
		{
			this.Textures = new TextureLoader(renderContext);
			this.Fonts = new FontLoader();
		}

		public IResourceLoader<Font> Fonts { get; set; }

		public IResourceLoader<Texture> Textures { get; set; }
	}
}