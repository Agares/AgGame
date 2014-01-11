namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Gui;
	using AgaresGame.Engine.Mathematics;

	public class ClickEventArgs : EventArgs
	{
		public ClickEventArgs(MouseButtons button, Point2 position)
		{
			this.Button = button;
			this.Position = position;
		}

		public MouseButtons Button { get; private set; }

		public Point2 Position { get; private set; }
	}
}