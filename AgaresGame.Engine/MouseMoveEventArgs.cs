using System;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine
{
	public class MouseMoveEventArgs : EventArgs
	{
		public Point2 Position { get; private set; }

		public MouseMoveEventArgs(Point2 position)
		{
			Position = position;
		}
	}
}