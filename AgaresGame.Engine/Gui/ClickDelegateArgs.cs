using System;

namespace AgaresGame.Engine.Gui
{
	public class ClickDelegateArgs : EventArgs
	{
		public MouseButtons MouseButton { get; private set; }

		public ClickDelegateArgs(MouseButtons button)
		{
			MouseButton = button;
		}
	}
}