namespace AgaresGame.Engine.Gui
{
	using System;

	public class ClickDelegateArgs : EventArgs
	{
		public ClickDelegateArgs(MouseButtons button)
		{
			this.MouseButton = button;
		}

		public MouseButtons MouseButton { get; private set; }
	}
}