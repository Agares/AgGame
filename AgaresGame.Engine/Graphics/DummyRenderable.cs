using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Graphics
{
	public class DummyRenderable : ISizedRenderable
	{
		public void Render(RenderContext context, Point2 position)
		{
			
		}

		public Vector2 Size
		{
			get
			{
				return new Vector2(0, 0);
			}
		}
	}
}