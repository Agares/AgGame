using System;
using System.Collections.Generic;
using AgaresGame.Engine;
using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Gui;
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
		private SpriteSheet _guiSpriteSheet;
		private Button _button;

		public MyGame(Window window) : base(window)
		{
			GameEvents.KeyDown += KeyDownHandler;
		}

		protected override void RenderFrame()
		{
			RenderContext.Clear();

			RenderContext.Render(_map, new Point2(0,0));
			RenderContext.Render(new Text(_font, LastRenderTime.FramesPerSecond.ToString("F2")), new Point2(0, 0));
			RenderContext.Render(_button, new Point2(100, 150));

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

			_guiSpriteSheet = new SpriteSheet(resourceManager.Textures["gui.png"], new Dictionary<int, Rectangle>
			{
				{0, new Rectangle(new Point2(3, 0), new Vector2(1, 3))},
				{1, new Rectangle(new Point2(0, 3), new Vector2(3, 1))},
				{2, new Rectangle(new Point2(125, 3), new Vector2(3, 1))},
				{3, new Rectangle(new Point2(3, 23), new Vector2(1, 3))},
				{4, new Rectangle(new Point2(3, 3), new Vector2(1, 1))},
				{5, new Rectangle(new Point2(0, 0), new Vector2(3, 3))}
			});

			_map.Objects.Add(new MapObject
			{
				PositionInTiles = new Point2(1, 0),
				Renderable = _spriteSheet[0],
				RenderDimensions = _spriteSheet[0].Rectangle.Size
			});

			_button = new Button(GameEvents, new ButtonAppearance
			{
				Background = _guiSpriteSheet[4],
				Padding = new Padding {Top = 10,Left=10,Right=10,Bottom = 10}
			}, new Text(_font, "Testful button"));
			_button.Click += (sender, args) => Console.WriteLine("Button click, btn: " + args.MouseButton.ToString());
		}

		protected void KeyDownHandler(object sender, KeyDownEventArgs keyDownEventArgs)
		{
			switch (keyDownEventArgs.Key)
			{
				case Keys.Left:
					_map.Shift = new Vector2(_map.Shift.X + 1, _map.Shift.Y);
					break;
				case Keys.Right:
					_map.Shift = new Vector2(_map.Shift.X - 1, _map.Shift.Y);
					break;
				case Keys.Up:
					_map.Shift = new Vector2(_map.Shift.X, _map.Shift.Y + 1);
					break;
				case Keys.Down:
					_map.Shift = new Vector2(_map.Shift.X, _map.Shift.Y - 1);
					break;
			}
		}
	}
}