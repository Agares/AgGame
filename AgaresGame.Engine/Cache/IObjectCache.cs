namespace AgaresGame.Engine.Cache
{
	using System;

	public interface IObjectCache<T> : IDisposable
	{
		T Get(string key);

		T GetOrDefault(string key, T defaultValue = default(T));

		bool IsInCache(string key);

		void Set(string key, T obj, TimeSpan duration);

		T TryGet(string key, TimeSpan duration, Func<T> factory);
	}
}