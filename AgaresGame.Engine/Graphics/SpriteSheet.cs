namespace AgaresGame.Engine.Graphics
{
	using System.Collections.Generic;
	using System.Linq;

	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources.Graphics;

	public class SpriteSheet
	{
		private readonly IDictionary<int, Sprite> sprites;

		private readonly Texture texture;

		public SpriteSheet(Texture texture, IEnumerable<KeyValuePair<int, Rectangle>> sprites)
		{
			this.texture = texture;
			this.sprites =
				sprites.Select(x => new KeyValuePair<int, Sprite>(x.Key, new Sprite(this.texture, x.Value)))
					.ToDictionary(x => x.Key, x => x.Value);
		}

		public Sprite this[int i]
		{
			get
			{
				return this.sprites[i];
			}
		}
	}
}