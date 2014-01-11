namespace AgaresGame.Engine
{
	using System;

	public class KeyDownEventArgs : EventArgs
	{
		public KeyDownEventArgs(Keys key, Modifiers modifier)
		{
			this.Key = key;
			this.Modifier = modifier;
		}

		public Keys Key { get; private set; }

		public Modifiers Modifier { get; private set; }
	}
}