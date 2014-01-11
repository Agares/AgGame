namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Gui;
	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources.Graphics;

	public class Sprite : IScalableSizedRenderable, IRenderablePartially
	{
		private readonly Texture texture;

		public Sprite(Texture texture, Rectangle rectangle)
		{
			this.texture = texture;
			this.Rectangle = rectangle;
		}

		public Rectangle Rectangle { get; private set; }

		public Vector2 Size
		{
			get
			{
				return this.Rectangle.Size;
			}
		}

		public void RenderFragment(RenderContext context, Rectangle fragment, Point2 position)
		{
			this.texture.Render(
				context, 
				new Rectangle(this.Rectangle.Position + new Vector2(fragment.Position), fragment.Size), 
				new Rectangle(position, fragment.Size));
		}

		public void Render(RenderContext context, Point2 position)
		{
			this.texture.Render(context, this.Rectangle, new Rectangle(position, this.Size));
		}

		public void RenderScaled(RenderContext context, Rectangle destination)
		{
			this.texture.Render(context, this.Rectangle, destination);
		}
	}
}