using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Graphics
{
	public class Tile : IRenderable
	{
		private readonly int _index;
		private readonly TileSet _tileSet;

		internal Tile(TileSet tileSet, int index)
		{
			_tileSet = tileSet;
			_index = index;
		}

		public void Render(RenderContext renderContext, Point2 destination)
		{
			_tileSet.Render(renderContext, _index, new Rectangle(destination, new Vector2(_tileSet.TileSize, _tileSet.TileSize)));
		}
	}
}