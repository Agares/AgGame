using System.Windows.Forms;
using AgaresGame.Engine.Mathematics;
using AgaresGame.Engine.Resources.Graphics;

namespace AgaresGame.Engine.Graphics
{
	public class Text : IRenderable, ISizedRenderable
	{
		private readonly Font _font;
		private readonly string _text;

		public Text(Font font, string text)
		{
			_font = font;
			_text = text;
		}

		public Vector2 Size
		{
			get { return _font.ComputeSize(_text); }
		}

		public void Render(RenderContext context, Point2 position)
		{
			_font.Render(context, _text, position);
		}
	}
}