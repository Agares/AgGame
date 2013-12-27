using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Graphics
{
	public interface IRenderablePartially : IRenderable
	{
		void RenderFragment(RenderContext context, Rectangle fragment, Point2 position);
	}
}