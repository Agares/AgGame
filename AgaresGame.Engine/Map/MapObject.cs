namespace AgaresGame.Engine.Map
{
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;

	public class MapObject
	{
		public Point2 PositionInTiles { get; set; }

		public Vector2 RenderDimensions { get; set; }

		public IRenderablePartially Renderable { get; set; }
	}
}