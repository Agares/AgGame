namespace AgaresGame.Engine.Mathematics
{
	public class Rectangle
	{
		public Rectangle(Point2 position, Vector2 size)
		{
			this.Position = position;
			this.Size = size;
		}

		public int Area
		{
			get
			{
				return this.Size.X * this.Size.Y;
			}
		}

		public Point2 Position { get; private set; }

		public Vector2 Size { get; private set; }

		public bool Contains(Point2 point)
		{
			Point2 secondVertex = this.Position + this.Size;

			return point.X <= secondVertex.X && point.Y <= secondVertex.Y && point.X >= this.Position.X
					&& point.Y >= this.Position.Y;
		}
	}
}