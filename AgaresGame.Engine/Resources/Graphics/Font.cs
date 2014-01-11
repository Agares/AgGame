namespace AgaresGame.Engine.Resources.Graphics
{
	using System;

	using AgaresGame.Engine.Cache;
	using AgaresGame.Engine.Mathematics;

	public class Font : IResource
	{
		private readonly IObjectCache<SizedFont> cache = new InMemoryObjectCache<SizedFont>();

		private readonly string filename;

		public Font(string filename)
		{
			this.filename = filename;
			this.Appearance = new FontAppearance();
		}

		public FontAppearance Appearance { get; set; }

		private string CacheKey
		{
			get
			{
				return string.Format("{0}#{1}", this.filename, this.Appearance.Size);
			}
		}

		private SizedFont CurrentSizedFont
		{
			get
			{
				return this.cache.TryGet(this.CacheKey, TimeSpan.MaxValue, () => new SizedFont(this.filename, this.Appearance.Size));
			}
		}

		public void Dispose()
		{
		}

		public Vector2 ComputeSize(string text)
		{
			return this.CurrentSizedFont.ComputeSize(text);
		}

		public void Render(RenderContext renderContext, string text, Point2 destination)
		{
			this.CurrentSizedFont.Render(renderContext, text, destination, this.Appearance.Color);
		}
	}
}