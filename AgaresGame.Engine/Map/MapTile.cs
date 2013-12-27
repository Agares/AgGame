using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Map
{
	public class MapTile : IRenderable
	{
		private readonly int _x;
		private readonly int _y;

		public IRenderable Tile { get; set; }

		public MapTile(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public void Render(RenderContext context, Point2 position)
		{
			Tile.Render(context, position);
		}
	}
}