namespace AgaresGame.Engine.Mathematics
{
	using System;

	public class Vector2
	{
		public static readonly Vector2 Zero = new Vector2(0, 0);

		public Vector2(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public Vector2(Point2 position)
		{
			this.X = position.X;
			this.Y = position.Y;
		}

		public double Length
		{
			get
			{
				return Math.Sqrt(((double)this.X * this.X) + ((double)this.Y * this.Y));
			}
		}

		public int X { get; private set; }

		public int Y { get; private set; }

		public static Vector2 operator +(Vector2 first, Vector2 second)
		{
			return new Vector2(first.X + second.X, first.Y + second.Y);
		}

		public static Vector2 operator *(Vector2 vector, int scalar)
		{
			return new Vector2(vector.X * scalar, vector.Y * scalar);
		}

		public static Vector2 operator *(Vector2 vector, double scalar)
		{
			return new Vector2((int)(vector.X * scalar), (int)(vector.Y * scalar));
		}

		public static Vector2 operator -(Vector2 first, Vector2 second)
		{
			return new Vector2(first.X - second.X, first.Y - second.Y);
		}
	}
}