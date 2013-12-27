namespace AgaresGame.Engine.Mathematics
{
	public class Rectangle
	{
		public Rectangle(Point2 position, Vector2 size)
		{
			Position = position;
			Size = size;
		}

		public Point2 Position { get; private set; }
		public Vector2 Size { get; private set; }

		public int Area
		{
			get { return Size.X*Size.Y; }
		}

		public bool Contains(Point2 point)
		{
			var secondVertex = Position + Size;

			return point.X <= secondVertex.X 
				&& point.Y <= secondVertex.Y
				&& point.X >= Position.X 
				&& point.Y >= Position.Y;
		}
	}
}