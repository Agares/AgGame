namespace AgaresGame.Engine.Gui
{
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;

	public interface IScalableSizedRenderable : ISizedRenderable
	{
		void RenderScaled(RenderContext context, Rectangle destination);
	}
}