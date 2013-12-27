using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Map
{
	public class MapRenderer
	{
		public Vector2 Shift { get; set; }
		public Rectangle RenderArea { get; set; }
		public Map Map { get; private set; }
		
		public int TileSize
		{
			get { return Map.TileSet.TileSize; }
		}

		private Vector2 DimensionsInTiles
		{
			get { return new Vector2(RenderArea.Size.X / TileSize, RenderArea.Size.Y / TileSize); }
		}

		private RenderContext _renderContext;

		public void Render(RenderContext context, Rectangle renderArea, Map map)
		{
			Shift = map.Shift;
			RenderArea = renderArea;
			Map = map;

			_renderContext = context;

			RenderTiles();
			RenderObjects();
		}

		private void RenderTiles()
		{
			for (int x = 0; x < DimensionsInTiles.X; x++)
			{
				for (int y = 0; y < DimensionsInTiles.Y; y++)
				{
					var mapTileRenderer = new MapTileRenderer(this, new Point2(x,y));
					mapTileRenderer.Render(_renderContext);
				}
			}
		}

		private void RenderObjects()
		{
			foreach (var objectToRender in Map.Objects)
			{
				var mapObjectRenderer = new MapObjectRenderer(this, objectToRender);
				mapObjectRenderer.Render(_renderContext);
			}
		}
	}
}