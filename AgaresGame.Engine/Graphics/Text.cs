using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class Text : IRenderable
	{
		private readonly Font _font;
		private readonly string _text;

		public Text(Font font, string text)
		{
			_font = font;
			_text = text;
		}

		public void Render(RenderContext context, Point2 position)
		{
			_font.Render(context, _text, position);
		}
	}
}