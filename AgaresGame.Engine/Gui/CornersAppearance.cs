using AgaresGame.Engine.Graphics;

namespace AgaresGame.Engine.Gui
{
	public class CornersAppearance
	{
		public ISizedRenderable TopLeft { get; set; }
		public ISizedRenderable TopRight { get; set; }
		public ISizedRenderable BottomLeft { get; set; }
		public ISizedRenderable BottomRight { get; set; }

		public CornersAppearance()
		{
			TopLeft = new DummyRenderable();
			TopRight = new DummyRenderable();
			BottomLeft = new DummyRenderable();
			BottomRight = new DummyRenderable();
		}
	}
}