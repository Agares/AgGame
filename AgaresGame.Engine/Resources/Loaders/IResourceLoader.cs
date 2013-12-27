using System;

namespace AgaresGame.Engine.Resources.Loaders
{
	public interface IResourceLoader<out T> : IDisposable where T : IResource
	{
		T this[string identifier] { get; }
	}
}