namespace AgaresGame.Engine.Resources.Loaders
{
	using System;

	using AgaresGame.Engine.Cache;

	public abstract class CachedResourceLoader<T> : IResourceLoader<T>
		where T : class, IResource
	{
		private readonly IObjectCache<T> resourceCache = new InMemoryObjectCache<T>();

		public T this[string identifier]
		{
			get
			{
				T resource = this.resourceCache.TryGet(identifier, new TimeSpan(365, 0, 0, 0), () => this.LoadResource(identifier));
				if (resource == null)
				{
					throw new Exception("Resoource " + identifier + " not found!");
				}

				return resource;
			}
		}

		public void Dispose()
		{
			this.resourceCache.Dispose();
		}

		protected abstract T LoadResource(string identifier);
	}
}