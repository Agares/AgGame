namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;

	public interface IRenderablePartially : IRenderable
	{
		void RenderFragment(RenderContext context, Rectangle fragment, Point2 position);
	}
}