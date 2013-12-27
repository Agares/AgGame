using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class Sprite : IRenderablePartially
	{
		private readonly Texture _texture;
		public Rectangle Rectangle { get; private set; }

		public Sprite(Texture texture, Rectangle rectangle)
		{
			_texture = texture;
			Rectangle = rectangle;
		}

		public void Render(RenderContext context, Point2 position)
		{
			_texture.Render(context, Rectangle, new Rectangle(position, Rectangle.Size));
		}

		public void RenderFragment(RenderContext context, Rectangle fragment, Point2 position)
		{
			_texture.Render(context, new Rectangle(Rectangle.Position + new Vector2(fragment.Position), fragment.Size), new Rectangle(position, fragment.Size));
		}
	}
}