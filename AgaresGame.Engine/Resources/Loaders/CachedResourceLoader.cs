using System;
using AgaresGame.Engine.Cache;

namespace AgaresGame.Engine.Resources.Loaders
{
	public abstract class CachedResourceLoader<T> : IResourceLoader<T> where T : class, IResource
	{
		private readonly IObjectCache<T> _resourceCache = new InMemoryObjectCache<T>();

		public T this[string identifier]
		{
			get
			{
				var resource = _resourceCache.TryGet(identifier, new TimeSpan(365, 0, 0, 0), () => LoadResource(identifier));
				if (resource == null)
				{
					throw new Exception("Resoource " + identifier + " not found!");
				}
				return resource;
			}
		}

		public void Dispose()
		{
			_resourceCache.Dispose();
		}

		protected abstract T LoadResource(string identifier);
	}
}