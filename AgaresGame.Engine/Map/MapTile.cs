namespace AgaresGame.Engine.Map
{
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;

	public class MapTile : IRenderable
	{
		public IRenderable Tile { get; set; }

		public void Render(RenderContext context, Point2 position)
		{
			this.Tile.Render(context, position);
		}
	}
}