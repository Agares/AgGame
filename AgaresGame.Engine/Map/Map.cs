namespace AgaresGame.Engine.Map
{
	using System.Collections.Generic;

	using AgaresGame.Engine.Extensions;
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;

	public class Map : IRenderable
	{
		private readonly Vector2 renderDimensions;

		private readonly MapRenderer renderer;

		private readonly MapTile[,] tiles;

		private Vector2 shift;

		public Map(TileSet tileSet, Vector2 renderDimensions, Vector2 dimensions)
		{
			this.Objects = new List<MapObject>();
			this.TileSet = tileSet;
			this.Dimensions = dimensions;
			this.Shift = Vector2.Zero;

			this.tiles = new MapTile[dimensions.X, dimensions.Y];
			this.renderer = new MapRenderer();
			this.renderDimensions = renderDimensions;

			this.InitializeTiles();
		}

		public Vector2 Dimensions { get; private set; }

		public IList<MapObject> Objects { get; private set; }

		public Vector2 Shift
		{
			get
			{
				return this.shift;
			}

			set
			{
				this.shift = new Vector2(value.X.Clamp(0, this.Dimensions.X - 1), value.Y.Clamp(0, this.Dimensions.Y - 1));
			}
		}

		public TileSet TileSet { get; private set; }

		public MapTile this[int x, int y]
		{
			get
			{
				return this.tiles[x, y];
			}
		}

		public void Render(RenderContext context, Point2 position)
		{
			this.renderer.Render(context, new Rectangle(position, this.renderDimensions), this);
		}

		private void InitializeTiles()
		{
			for (int i = 0; i < this.Dimensions.X; i++)
			{
				for (int j = 0; j < this.Dimensions.Y; j++)
				{
					this.tiles[i, j] = new MapTile { Tile = this.TileSet[0] };
				}
			}
		}
	}
}