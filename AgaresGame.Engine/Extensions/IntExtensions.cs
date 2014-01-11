namespace AgaresGame.Engine.Extensions
{
	using System;

	public static class IntExtensions
	{
		public static int Clamp(this int self, int min, int max)
		{
			return Math.Min(max, self.Clamp(min));
		}

		public static int Clamp(this int self, int min)
		{
			return Math.Max(min, self);
		}

		public static bool InRangeExclusive(this int self, int min, int max)
		{
			return self > min && self < max;
		}

		public static bool InRangeInclusive(this int self, int min, int max)
		{
			return self >= min && self <= max;
		}
	}
}