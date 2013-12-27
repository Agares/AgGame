using System;
using AgaresGame.Engine.Cache;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Resources.Graphics
{
	public class Font : IResource
	{
		private readonly IObjectCache<FontWithSize> _cache = new InMemoryObjectCache<FontWithSize>();
		private readonly string _filename;

		public Font(string filename)
		{
			_filename = filename;
			Appearance = new FontAppearance();
		}

		public FontAppearance Appearance { get; set; }


		public void Dispose()
		{
		}

		public void Render(RenderContext renderContext, string text, Point2 destination)
		{
			FontWithSize sizedFont = _cache.TryGet(_filename + " -- " + Appearance.Size, new TimeSpan(365, 0, 0, 0),
				() => new FontWithSize(_filename, Appearance.Size));
			sizedFont.Render(renderContext, text, destination, Appearance.Color);
		}
	}
}