using System;

namespace AgaresGame.Engine
{
	public class KeyDownEventArgs : EventArgs
	{
		public Keys Key { get; private set; }
		public Modifiers Modifier { get; private set; }

		public KeyDownEventArgs(Keys key, Modifiers modifier)
		{
			Key = key;
			Modifier = modifier;
		}
	}
}