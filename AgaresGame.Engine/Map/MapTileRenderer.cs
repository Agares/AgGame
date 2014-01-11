namespace AgaresGame.Engine.Map
{
	using AgaresGame.Engine.Extensions;
	using AgaresGame.Engine.Mathematics;

	public class MapTileRenderer
	{
		private readonly MapRenderer mapRenderer;

		private readonly Point2 relativePosition;

		public MapTileRenderer(MapRenderer mapRenderer, Point2 relativePosition)
		{
			this.mapRenderer = mapRenderer;
			this.relativePosition = relativePosition;
		}

		private Point2 AbsolutePosition
		{
			get
			{
				return new Point2(
					this.relativePosition.X + this.mapRenderer.Shift.X, 
					this.relativePosition.Y + this.mapRenderer.Shift.Y);
			}
		}

		private Point2 OnScreenPosition
		{
			get
			{
				return this.mapRenderer.RenderArea.Position
						+ new Vector2(
							this.relativePosition.X * this.mapRenderer.TileSize, 
							this.relativePosition.Y * this.mapRenderer.TileSize);
			}
		}

		private bool TileExists
		{
			get
			{
				return this.AbsolutePosition.X.InRangeInclusive(0, this.mapRenderer.Map.Dimensions.X - 1)
						&& this.AbsolutePosition.X.InRangeInclusive(0, this.mapRenderer.Map.Dimensions.Y - 1);
			}
		}

		public void Render(RenderContext renderContext)
		{
			if (!this.TileExists)
			{
				return;
			}

			this.mapRenderer.Map[this.AbsolutePosition.X, this.AbsolutePosition.Y].Render(renderContext, this.OnScreenPosition);
		}
	}
}