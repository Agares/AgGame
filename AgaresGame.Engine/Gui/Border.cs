namespace AgaresGame.Engine.Gui
{
	using AgaresGame.Engine.Graphics;

	public class Border
	{
		public ISizedRenderable BorderBottom { get; set; }

		public ISizedRenderable BorderLeft { get; set; }

		public ISizedRenderable BorderRight { get; set; }

		public ISizedRenderable BorderTop { get; set; }
	}
}