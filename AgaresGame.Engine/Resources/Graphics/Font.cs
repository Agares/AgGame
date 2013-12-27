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
			CurrentSizedFont.Render(renderContext, text, destination, Appearance.Color);
		}

		private FontWithSize CurrentSizedFont
		{
			get
			{
				return _cache.TryGet(CacheKey, TimeSpan.MaxValue, () => new FontWithSize(_filename, Appearance.Size));
			}
		}

		private string CacheKey
		{
			get { return string.Format("{0}#{1}", _filename, Appearance.Size); }
		}

		public Vector2 ComputeSize(string text)
		{
			return CurrentSizedFont.ComputeSize(text);
		}
	}
}