namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;

	public interface IRenderable
	{
		void Render(RenderContext context, Point2 position);
	}
}