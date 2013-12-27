using System;

namespace AgaresGame.Engine.Cache
{
	public interface IObjectCache<T> : IDisposable
	{
		void Set(string key, T obj, TimeSpan duration);
		T Get(string key);
		T GetOrDefault(string key, T defaultValue = default(T));
		T TryGet(string key, TimeSpan duration, Func<T> factory);
		bool IsInCache(string key);
	}
}