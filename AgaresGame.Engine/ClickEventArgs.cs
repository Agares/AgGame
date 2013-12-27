using System;
using AgaresGame.Engine.Gui;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine
{
	public class ClickEventArgs : EventArgs
	{
		public MouseButtons Button { get; private set; }
		public Point2 Position { get; private set; }

		public ClickEventArgs(MouseButtons button, Point2 position)
		{
			Button = button;
			Position = position;
		}
	}
}