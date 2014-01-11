namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;

	public class Tile : ISizedRenderable
	{
		private readonly int index;

		private readonly TileSet tileSet;

		internal Tile(TileSet tileSet, int index)
		{
			this.tileSet = tileSet;
			this.index = index;
		}

		public Vector2 Size
		{
			get
			{
				return new Vector2(this.tileSet.TileSize, this.tileSet.TileSize);
			}
		}

		public void Render(RenderContext renderContext, Point2 destination)
		{
			this.tileSet.Render(renderContext, this.index, new Rectangle(destination, this.Size));
		}
	}
}