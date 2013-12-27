using System;
using System.Collections.Generic;
using System.Linq;
using AgaresGame.Engine.Resources;

namespace AgaresGame.Engine.Cache
{
	internal class InMemoryObjectCache<T> : IObjectCache<T>
	{
		private readonly IDictionary<string, CacheItem> _cacheItems;

		public InMemoryObjectCache()
		{
			_cacheItems = new Dictionary<string, CacheItem>();
		}

		public void Set(string key, T obj, TimeSpan duration)
		{
			_cacheItems[key] = new CacheItem
			{
				Object = obj,
				Duration = duration,
				InsertionTime = DateTime.Now
			};
		}

		public T Get(string key)
		{
			if (IsInCache(key))
			{
				return GetUnchecked(key);
			}

			throw new ItemNotInCacheException();
		}

		public T GetOrDefault(string key, T defaultValue = default(T))
		{
			if (IsInCache(key))
			{
				return GetUnchecked(key);
			}

			return defaultValue;
		}

		public T TryGet(string key, TimeSpan lifetime, Func<T> factory)
		{
			if (IsInCache(key))
			{
				return GetUnchecked(key);
			}

			Set(key, factory(), lifetime);
			return GetUnchecked(key);
		}

		public bool IsInCache(string key)
		{
			if (!_cacheItems.ContainsKey(key))
			{
				return false;
			}

			CacheItem cacheItem = _cacheItems[key];
			bool outdated = (DateTime.Now - cacheItem.InsertionTime) > cacheItem.Duration;
			if (!outdated)
			{
				return true;
			}
			return false;
		}

		public void Dispose()
		{
			IEnumerable<IDisposable> disposableItems = _cacheItems.Select(x => x.Value.Object).OfType<IDisposable>();
			foreach (IDisposable item in disposableItems)
			{
				item.Dispose();
			}
		}

		private T GetUnchecked(string key)
		{
			return _cacheItems[key].Object;
		}

		private class CacheItem
		{
			public T Object { get; set; }
			public TimeSpan Duration { get; set; }
			public DateTime InsertionTime { get; set; }
		};
	}
}