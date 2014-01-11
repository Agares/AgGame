namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;

	public class DummyRenderable : ISizedRenderable
	{
		public Vector2 Size
		{
			get
			{
				return new Vector2(0, 0);
			}
		}

		public void Render(RenderContext context, Point2 position)
		{
		}
	}
}