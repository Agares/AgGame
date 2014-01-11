namespace AgaresGame.Engine.Cache
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	internal class InMemoryObjectCache<T> : IObjectCache<T>
	{
		private readonly IDictionary<string, CacheItem> cacheItems;

		public InMemoryObjectCache()
		{
			this.cacheItems = new Dictionary<string, CacheItem>();
		}

		public void Dispose()
		{
			IEnumerable<IDisposable> disposableItems = this.cacheItems.Select(x => x.Value.Object).OfType<IDisposable>();
			foreach (IDisposable item in disposableItems)
			{
				item.Dispose();
			}
		}

		public T Get(string key)
		{
			if (this.IsInCache(key))
			{
				return this.GetUnchecked(key);
			}

			throw new ItemNotInCacheException();
		}

		public T GetOrDefault(string key, T defaultValue = default(T))
		{
			if (this.IsInCache(key))
			{
				return this.GetUnchecked(key);
			}

			return defaultValue;
		}

		public bool IsInCache(string key)
		{
			if (!this.cacheItems.ContainsKey(key))
			{
				return false;
			}

			CacheItem cacheItem = this.cacheItems[key];
			bool outdated = (DateTime.Now - cacheItem.InsertionTime) > cacheItem.Duration;
			if (!outdated)
			{
				return true;
			}

			return false;
		}

		public void Set(string key, T obj, TimeSpan duration)
		{
			this.cacheItems[key] = new CacheItem { Object = obj, Duration = duration, InsertionTime = DateTime.Now };
		}

		public T TryGet(string key, TimeSpan lifetime, Func<T> factory)
		{
			if (this.IsInCache(key))
			{
				return this.GetUnchecked(key);
			}

			this.Set(key, factory(), lifetime);
			return this.GetUnchecked(key);
		}

		private T GetUnchecked(string key)
		{
			return this.cacheItems[key].Object;
		}

		private class CacheItem
		{
			public TimeSpan Duration { get; set; }

			public DateTime InsertionTime { get; set; }

			public T Object { get; set; }
		}
	}
}