namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;
	using AgaresGame.Engine.Resources.Graphics;

	public class Text : ISizedRenderable
	{
		private readonly Font font;

		private readonly string text;

		public Text(Font font, string text)
		{
			this.font = font;
			this.text = text;
		}

		public Vector2 Size
		{
			get
			{
				return this.font.ComputeSize(this.text);
			}
		}

		public void Render(RenderContext context, Point2 position)
		{
			this.font.Render(context, this.text, position);
		}
	}
}