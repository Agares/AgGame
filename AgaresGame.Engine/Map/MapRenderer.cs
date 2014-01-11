namespace AgaresGame.Engine.Map
{
	using AgaresGame.Engine.Mathematics;

	public class MapRenderer
	{
		private RenderContext renderContext;

		public Map Map { get; private set; }

		public Rectangle RenderArea { get; set; }

		public Vector2 Shift { get; set; }

		public int TileSize
		{
			get
			{
				return this.Map.TileSet.TileSize;
			}
		}

		private Vector2 DimensionsInTiles
		{
			get
			{
				return new Vector2(this.RenderArea.Size.X / this.TileSize, this.RenderArea.Size.Y / this.TileSize);
			}
		}

		public void Render(RenderContext context, Rectangle renderArea, Map map)
		{
			this.Shift = map.Shift;
			this.RenderArea = renderArea;
			this.Map = map;

			this.renderContext = context;

			this.RenderTiles();
			this.RenderObjects();
		}

		private void RenderObjects()
		{
			foreach (MapObject objectToRender in this.Map.Objects)
			{
				var mapObjectRenderer = new MapObjectRenderer(this, objectToRender);
				mapObjectRenderer.Render(this.renderContext);
			}
		}

		private void RenderTiles()
		{
			for (int x = 0; x < this.DimensionsInTiles.X; x++)
			{
				for (int y = 0; y < this.DimensionsInTiles.Y; y++)
				{
					var mapTileRenderer = new MapTileRenderer(this, new Point2(x, y));
					mapTileRenderer.Render(this.renderContext);
				}
			}
		}
	}
}