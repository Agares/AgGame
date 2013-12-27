using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Gui
{
	public interface IScalableSizedRenderable : ISizedRenderable
	{
		void RenderScaled(RenderContext context, Rectangle destination);
	}
}