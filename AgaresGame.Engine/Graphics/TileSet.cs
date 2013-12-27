using System.Collections.Generic;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class TileSet
	{
		private readonly Texture _texture;
		private readonly int _tileSize;
		private readonly IList<Tile> _tiles = new List<Tile>();

		public TileSet(Texture texture, int tileSize)
		{
			_texture = texture;
			_tileSize = tileSize;

			for (int i = 0; i < TileCount; i++)
			{
				_tiles.Add(new Tile(this, i));
			}
		}

		public int Width
		{
			get { return _texture.Width/_tileSize; }
		}

		public int Height
		{
			get { return _texture.Height/_tileSize; }
		}

		public int TileCount
		{
			get { return Width*Height; }
		}

		public int TileSize
		{
			get { return _tileSize; }
		}

		public Tile this[int tileIndex]
		{
			get { return _tiles[tileIndex]; }
		}

		public void Render(RenderContext renderContext, int index, Rectangle destination)
		{
			_texture.Render(renderContext, new Rectangle(RelativeOnScreenPositionFromIndex(index), new Vector2(_tileSize, _tileSize)), destination);
		}

		private Point2 RelativeOnScreenPositionFromIndex(int index)
		{
			return new Point2(_tileSize*(index%Height), _tileSize*(index/Width));
		}
	}
}