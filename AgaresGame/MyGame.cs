using System.Collections.Generic;
using AgaresGame.Engine;
using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Map;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources;
using AgaresGame.Engine.Resources.Graphics;
using Color = AgaresGame.Engine.Graphics.Color;
using Font = AgaresGame.Engine.Resources.Graphics.Font;
using Rectangle = AgaresGame.Engine.Mathematics.Rectangle;

namespace AgaresGame
{
	public class MyGame : GameLoop
	{
		private Font _font;
		private Map _map;
		private TileSet _mapTileSet;
		private SpriteSheet _spriteSheet;

		public MyGame(Window window) : base(window)
		{
		}

		protected override void RenderFrame()
		{
			RenderContext.Clear();

			RenderContext.Render(_map, new Point2(0,0));
			RenderContext.Render(new Text(_font, LastRenderTime.FramesPerSecond.ToString("F2")), new Point2(0, 0));

			RenderContext.Present();
		}

		protected override void LoadResources(ResourceManager resourceManager)
		{
			_mapTileSet = new TileSet(resourceManager.Textures["tiles.png"], 32);
			_font = resourceManager.Fonts["font.ttf"];
			_font.Appearance = new FontAppearance
			{
				Size = 32,
				Color = new Color(255, 255, 0, 255),
			};
			_map = new Map(_mapTileSet, new Vector2(640, 480), new Vector2(64,64));
			_map[0, 0].Tile = _mapTileSet[1];
			_map[0, 1].Tile = _mapTileSet[1];
			_map[0, 2].Tile = _mapTileSet[1];
			_map[0, 3].Tile = _mapTileSet[1];
			_map[1, 3].Tile = _mapTileSet[1];

			_spriteSheet = new SpriteSheet(resourceManager.Textures["hacjenda.png"],new Dictionary<int, Rectangle>
			{
				{0, new Rectangle(Point2.Zero, new Vector2(128, 96))}
			});

			_map.Objects.Add(new MapObject
			{
				PositionInTiles = new Point2(1, 0),
				Renderable = _spriteSheet[0],
				RenderDimensions = _spriteSheet[0].Rectangle.Size
			});
		}

		protected override void OnQuit()
		{
		}

		protected override void OnKeyDown(Keys key, Modifiers modifier)
		{
			if (key == Keys.Left)
			{
				_map.Shift = new Vector2(_map.Shift.X + 1, _map.Shift.Y);
			}
			else if (key == Keys.Right)
			{
				_map.Shift = new Vector2(_map.Shift.X - 1, _map.Shift.Y);
			}
			else if (key == Keys.Up)
			{
				_map.Shift = new Vector2(_map.Shift.X, _map.Shift.Y + 1);
			}
			else if (key == Keys.Down)
			{
				_map.Shift = new Vector2(_map.Shift.X, _map.Shift.Y - 1);
			}
		}

		protected override void OnMouseMove(Point2 position)
		{
		}
	}
}