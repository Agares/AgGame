using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Graphics
{
	public interface IRenderable
	{
		void Render(RenderContext context, Point2 position);
	}
}