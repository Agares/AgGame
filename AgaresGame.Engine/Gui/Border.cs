using AgaresGame.Engine.Graphics;

namespace AgaresGame.Engine.Gui
{
	public class Border
	{
		public ISizedRenderable BorderTop { get; set; }
		public ISizedRenderable BorderLeft { get; set; }
		public ISizedRenderable BorderRight { get; set; }
		public ISizedRenderable BorderBottom { get; set; }
	}
}