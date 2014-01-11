namespace AgaresGame.Engine.Map
{
	using AgaresGame.Engine.Extensions;
	using AgaresGame.Engine.Mathematics;

	public class MapObjectRenderer
	{
		private readonly MapObject mapObject;

		private readonly MapRenderer mapRenderer;

		public MapObjectRenderer(MapRenderer mapRenderer, MapObject mapObject)
		{
			this.mapRenderer = mapRenderer;
			this.mapObject = mapObject;
		}

		private Vector2 FirstVertex
		{
			get
			{
				Vector2 firstVertex = new Vector2(this.RelativePosition) * this.mapRenderer.TileSize;
				firstVertex = new Vector2(firstVertex.X.Clamp(0), firstVertex.Y.Clamp(0));
				return firstVertex;
			}
		}

		private bool IsOnScreen
		{
			get
			{
				return this.SecondVertex.X > 0 && this.SecondVertex.Y > 0
						&& this.FirstVertex.X <= this.mapRenderer.RenderArea.Size.X
						&& this.FirstVertex.Y <= this.mapRenderer.RenderArea.Size.Y;
			}
		}

		private Vector2 OffScreenArea
		{
			get
			{
				Vector2 offScreenArea = new Vector2(this.RelativePosition) * this.mapRenderer.TileSize * -1;
				offScreenArea = new Vector2(offScreenArea.X.Clamp(0), offScreenArea.Y.Clamp(0));
				return offScreenArea;
			}
		}

		private Point2 RelativePosition
		{
			get
			{
				return new Point2(
					this.mapObject.PositionInTiles.X - this.mapRenderer.Shift.X, 
					this.mapObject.PositionInTiles.Y - this.mapRenderer.Shift.Y);
			}
		}

		private Vector2 SecondVertex
		{
			get
			{
				return this.FirstVertex + this.mapObject.RenderDimensions;
			}
		}

		public void Render(RenderContext renderContext)
		{
			if (!this.IsOnScreen)
			{
				return;
			}

			Vector2 dimensionsToRender = this.mapObject.RenderDimensions - this.OffScreenArea;

			this.mapObject.Renderable.RenderFragment(
				renderContext, 
				new Rectangle(new Point2(this.OffScreenArea), dimensionsToRender), 
				new Point2(this.FirstVertex));
		}
	}
}