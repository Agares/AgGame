namespace AgaresGame
{
	using System;
	using System.Collections.Generic;

	using AgaresGame.Engine;
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Gui;
	using AgaresGame.Engine.Map;
	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources;
	using AgaresGame.Engine.Resources.Graphics;

	public class MyGame : GameLoop
	{
		private Button button;

		private Font font;

		private SpriteSheet guiSpriteSheet;

		private Map map;

		private TileSet mapTileSet;

		private SpriteSheet spriteSheet;

		public MyGame(Window window)
			: base(window)
		{
			this.GameEvents.KeyDown += this.KeyDownHandler;
		}

		protected void KeyDownHandler(object sender, KeyDownEventArgs keyDownEventArgs)
		{
			switch (keyDownEventArgs.Key)
			{
				case Keys.Left:
					this.map.Shift = new Vector2(this.map.Shift.X + 1, this.map.Shift.Y);
					break;
				case Keys.Right:
					this.map.Shift = new Vector2(this.map.Shift.X - 1, this.map.Shift.Y);
					break;
				case Keys.Up:
					this.map.Shift = new Vector2(this.map.Shift.X, this.map.Shift.Y + 1);
					break;
				case Keys.Down:
					this.map.Shift = new Vector2(this.map.Shift.X, this.map.Shift.Y - 1);
					break;
			}
		}

		protected override void LoadResources(ResourceManager resourceManager)
		{
			this.mapTileSet = new TileSet(resourceManager.Textures["tiles.png"], 32);
			this.font = resourceManager.Fonts["font.ttf"];
			this.font.Appearance = new FontAppearance { Size = 32, Color = new Color(255, 255, 0, 255), };
			this.map = new Map(this.mapTileSet, new Vector2(640, 480), new Vector2(64, 64));
			this.map[0, 0].Tile = this.mapTileSet[1];
			this.map[0, 1].Tile = this.mapTileSet[1];
			this.map[0, 2].Tile = this.mapTileSet[1];
			this.map[0, 3].Tile = this.mapTileSet[1];
			this.map[1, 3].Tile = this.mapTileSet[1];

			this.spriteSheet = new SpriteSheet(
				resourceManager.Textures["hacjenda.png"], 
				new Dictionary<int, Rectangle> { { 0, new Rectangle(Point2.Zero, new Vector2(128, 96)) } });

			this.guiSpriteSheet = new SpriteSheet(
				resourceManager.Textures["gui.png"], 
				new Dictionary<int, Rectangle>
					{
						{ 0, new Rectangle(new Point2(3, 0), new Vector2(1, 3)) }, 
						{ 1, new Rectangle(new Point2(0, 3), new Vector2(3, 1)) }, 
						{ 2, new Rectangle(new Point2(125, 3), new Vector2(3, 1)) }, 
						{ 3, new Rectangle(new Point2(3, 23), new Vector2(1, 3)) }, 
						{ 4, new Rectangle(new Point2(3, 3), new Vector2(1, 1)) }, 
						{ 5, new Rectangle(new Point2(0, 0), new Vector2(3, 3)) }
					});

			this.map.Objects.Add(
				new MapObject
					{
						PositionInTiles = new Point2(1, 0), 
						Renderable = this.spriteSheet[0], 
						RenderDimensions = this.spriteSheet[0].Rectangle.Size
					});

			this.button = new Button(
				this.GameEvents, 
				new ButtonAppearance
					{
						Background = this.guiSpriteSheet[4], 
						Padding = new Padding { Top = 10, Left = 10, Right = 10, Bottom = 10 }
					}, 
				new Text(this.font, "Testful button"));
			this.button.Click += (sender, args) => Console.WriteLine("Button click, btn: " + args.MouseButton.ToString());
		}

		protected override void RenderFrame()
		{
			this.RenderContext.Clear();

			this.RenderContext.Render(this.map, new Point2(0, 0));
			this.RenderContext.Render(new Text(this.font, this.LastRenderTime.FramesPerSecond.ToString("F2")), new Point2(0, 0));
			this.RenderContext.Render(this.button, new Point2(100, 150));

			this.RenderContext.Present();
		}
	}
}