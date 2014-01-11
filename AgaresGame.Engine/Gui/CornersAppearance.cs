namespace AgaresGame.Engine.Gui
{
	using AgaresGame.Engine.Graphics;

	public class CornersAppearance
	{
		public CornersAppearance()
		{
			this.TopLeft = new DummyRenderable();
			this.TopRight = new DummyRenderable();
			this.BottomLeft = new DummyRenderable();
			this.BottomRight = new DummyRenderable();
		}

		public ISizedRenderable BottomLeft { get; set; }

		public ISizedRenderable BottomRight { get; set; }

		public ISizedRenderable TopLeft { get; set; }

		public ISizedRenderable TopRight { get; set; }
	}
}