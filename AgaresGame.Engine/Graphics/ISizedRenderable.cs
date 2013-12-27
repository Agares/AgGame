using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Graphics
{
	public interface ISizedRenderable : IRenderable
	{
		Vector2 Size { get; }
	}
}