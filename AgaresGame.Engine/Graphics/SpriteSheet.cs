using System.Collections.Generic;
using System.Linq;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class SpriteSheet
	{
		private readonly IDictionary<int, Sprite> _sprites;
		private readonly Texture _texture;

		public Sprite this[int i]
		{
			get { return _sprites[i]; }
		}

		public SpriteSheet(Texture texture, IEnumerable<KeyValuePair<int, Rectangle>> sprites)
		{
			_texture = texture;
			_sprites = sprites.Select(x => new  KeyValuePair<int, Sprite>(x.Key, new Sprite(_texture, x.Value))).ToDictionary(x => x.Key, x => x.Value);
		}
	}
}