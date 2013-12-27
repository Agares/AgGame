using System.Collections.Generic;
using AgaresGame.Engine.Extensions;
using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Map
{
	public class Map : IRenderable
	{
		public TileSet TileSet { get; private set; }
		public Vector2 Dimensions { get; private set; }
		public IList<MapObject> Objects { get; private set; }

		private readonly MapTile[,] _tiles;
		private readonly Vector2 _renderDimensions;
		private readonly MapRenderer _renderer;
		private Vector2 _shift;

		public Vector2 Shift
		{
			get { return _shift; }
			set { _shift = new Vector2(value.X.Clamp(0, Dimensions.X - 1), value.Y.Clamp(0, Dimensions.Y - 1)); }
		}

		public MapTile this[int x, int y]
		{
			get { return _tiles[x, y]; }
		}

		public Map(TileSet tileSet, Vector2 renderDimensions, Vector2 dimensions)
		{
			Objects = new List<MapObject>();
			TileSet = tileSet;
			Dimensions = dimensions;
			Shift = Vector2.Zero;

			_tiles = new MapTile[dimensions.X,dimensions.Y];
			_renderer = new MapRenderer();
			_renderDimensions = renderDimensions;

			InitializeTiles();
		}

		private void InitializeTiles()
		{
			for (int i = 0; i < Dimensions.X; i++)
			{
				for (int j = 0; j < Dimensions.Y; j++)
				{
					_tiles[i, j] = new MapTile(i, j)
					{
						Tile = TileSet[0]
					};
				}
			}
		}

		public void Render(RenderContext context, Point2 position)
		{
			_renderer.Render(context, new Rectangle(position, _renderDimensions), this);
		}
	}
}