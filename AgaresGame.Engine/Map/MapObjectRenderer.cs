using AgaresGame.Engine.Extensions;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Map
{
	public class MapObjectRenderer
	{
		private readonly MapRenderer _mapRenderer;
		private readonly MapObject _mapObject;

		private Vector2 SecondVertex
		{
			get { return FirstVertex + _mapObject.RenderDimensions; }
		}

		private Point2 RelativePosition
		{
			get
			{
				return new Point2(_mapObject.PositionInTiles.X - _mapRenderer.Shift.X, _mapObject.PositionInTiles.Y - _mapRenderer.Shift.Y);
			}
		}

		private Vector2 OffScreenArea
		{
			get
			{
				var offScreenArea = new Vector2(RelativePosition) * _mapRenderer.TileSize * -1;
				offScreenArea = new Vector2(offScreenArea.X.Clamp(0), offScreenArea.Y.Clamp(0));
				return offScreenArea;
			}
		}

		private Vector2 FirstVertex
		{
			get
			{
				var firstVertex = new Vector2(RelativePosition) * _mapRenderer.TileSize;
				firstVertex = new Vector2(firstVertex.X.Clamp(0), firstVertex.Y.Clamp(0));
				return firstVertex;
			}
		}

		private bool IsOnScreen
		{
			get
			{
				return SecondVertex.X > 0 
					&& SecondVertex.Y > 0
					&& FirstVertex.X <= _mapRenderer.RenderArea.Size.X 
					&& FirstVertex.Y <= _mapRenderer.RenderArea.Size.Y;
			}
		}

		public MapObjectRenderer(MapRenderer mapRenderer, MapObject mapObject)
		{
			_mapRenderer = mapRenderer;
			_mapObject = mapObject;
		}

		public void Render(RenderContext renderContext)
		{
			if (!IsOnScreen)
			{
				return;
			}

			var dimensionsToRender = _mapObject.RenderDimensions - OffScreenArea;

			_mapObject.Renderable.RenderFragment(renderContext, new Rectangle(new Point2(OffScreenArea), dimensionsToRender), new Point2(FirstVertex));
		}
	}
}