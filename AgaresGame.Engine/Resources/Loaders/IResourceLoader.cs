namespace AgaresGame.Engine.Resources.Loaders
{
	using System;

	public interface IResourceLoader<out T> : IDisposable
		where T : IResource
	{
		T this[string identifier] { get; }
	}
}