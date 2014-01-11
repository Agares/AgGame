namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Mathematics;

	public class MouseMoveEventArgs : EventArgs
	{
		public MouseMoveEventArgs(Point2 position)
		{
			this.Position = position;
		}

		public Point2 Position { get; private set; }
	}
}