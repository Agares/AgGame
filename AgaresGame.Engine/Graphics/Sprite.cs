using AgaresGame.Engine.Gui;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class Sprite : IScalableSizedRenderable, IRenderablePartially
	{
		private readonly Texture _texture;
		public Rectangle Rectangle { get; private set; }

		public Vector2 Size { get { return Rectangle.Size; } }
		public Sprite(Texture texture, Rectangle rectangle)
		{
			_texture = texture;
			Rectangle = rectangle;
		}

		public void Render(RenderContext context, Point2 position)
		{
			_texture.Render(context, Rectangle, new Rectangle(position, Size));
		}

		public void RenderFragment(RenderContext context, Rectangle fragment, Point2 position)
		{
			_texture.Render(context, new Rectangle(Rectangle.Position + new Vector2(fragment.Position), fragment.Size), new Rectangle(position, fragment.Size));
		}

		public void RenderScaled(RenderContext context, Rectangle destination)
		{
			_texture.Render(context, Rectangle, destination);
		}

	}
}