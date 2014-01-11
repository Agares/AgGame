namespace AgaresGame.Engine.Graphics
{
	using System.Collections.Generic;

	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources.Graphics;

	public class TileSet
	{
		private readonly Texture texture;

		private readonly int tileSize;

		private readonly IList<Tile> tiles = new List<Tile>();

		public TileSet(Texture texture, int tileSize)
		{
			this.texture = texture;
			this.tileSize = tileSize;

			for (int i = 0; i < this.TileCount; i++)
			{
				this.tiles.Add(new Tile(this, i));
			}
		}

		public int Height
		{
			get
			{
				return this.texture.Height / this.tileSize;
			}
		}

		public int TileCount
		{
			get
			{
				return this.Width * this.Height;
			}
		}

		public int TileSize
		{
			get
			{
				return this.tileSize;
			}
		}

		public int Width
		{
			get
			{
				return this.texture.Width / this.tileSize;
			}
		}

		public Tile this[int tileIndex]
		{
			get
			{
				return this.tiles[tileIndex];
			}
		}

		public void Render(RenderContext renderContext, int index, Rectangle destination)
		{
			this.texture.Render(
				renderContext, 
				new Rectangle(this.RelativeOnScreenPositionFromIndex(index), new Vector2(this.tileSize, this.tileSize)), 
				destination);
		}

		private Point2 RelativeOnScreenPositionFromIndex(int index)
		{
			return new Point2(this.tileSize * (index % this.Height), this.tileSize * (index / this.Width));
		}
	}
}