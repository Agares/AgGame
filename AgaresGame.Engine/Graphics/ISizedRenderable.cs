namespace AgaresGame.Engine.Graphics
{
	using AgaresGame.Engine.Mathematics;

	public interface ISizedRenderable : IRenderable
	{
		Vector2 Size { get; }
	}
}