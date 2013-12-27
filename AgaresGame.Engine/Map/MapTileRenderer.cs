using AgaresGame.Engine.Extensions;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Map
{
	public class MapTileRenderer
	{
		private readonly MapRenderer _mapRenderer;
		private readonly Point2 _relativePosition;

		private Point2 OnScreenPosition
		{
			get
			{
				return _mapRenderer.RenderArea.Position + new Vector2(_relativePosition.X * _mapRenderer.TileSize, _relativePosition.Y * _mapRenderer.TileSize);
			}
		}

		private Point2 AbsolutePosition
		{
			get
			{
				return new Point2(_relativePosition.X + _mapRenderer.Shift.X, _relativePosition.Y + _mapRenderer.Shift.Y);
			}
		}

		private bool TileExists
		{
			get
			{
				return AbsolutePosition.X.InRangeInclusive(0, _mapRenderer.Map.Dimensions.X - 1) &&
					   AbsolutePosition.X.InRangeInclusive(0, _mapRenderer.Map.Dimensions.Y - 1);
			}
		}

		public MapTileRenderer(MapRenderer mapRenderer, Point2 relativePosition)
		{
			_mapRenderer = mapRenderer;
			_relativePosition = relativePosition;
		}

		public void Render(RenderContext renderContext)
		{
			if (!TileExists)
			{
				return;
			}

			_mapRenderer.Map[AbsolutePosition.X, AbsolutePosition.Y].Render(renderContext, OnScreenPosition);
		}
	}
}