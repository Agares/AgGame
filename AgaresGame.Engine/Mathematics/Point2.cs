namespace AgaresGame.Engine.Mathematics
{
	public class Point2
	{
		public static readonly Point2 Zero = new Point2(0, 0);

		public Point2(int x, int y)
		{
			X = x;
			Y = y;
		}

		public Point2(Vector2 vector)
		{
			X = vector.X;
			Y = vector.Y;
		}

		public int X { get; private set; }
		public int Y { get; private set; }

		public static Point2 operator +(Point2 point, Vector2 vector)
		{
			return new Point2(point.X + vector.X, point.Y + vector.Y);
		}

		public static Point2 operator -(Point2 point, Vector2 vector)
		{
			return new Point2(point.X - vector.X, point.Y - vector.Y);
		}
	}
}