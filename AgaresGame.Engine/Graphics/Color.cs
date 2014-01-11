namespace AgaresGame.Engine.Graphics
{
	public class Color
	{
		public Color(byte r, byte g, byte b, byte a)
		{
			this.R = r;
			this.G = g;
			this.B = b;
			this.A = a;
		}

		public byte A { get; private set; }

		public byte B { get; private set; }

		public byte G { get; private set; }

		public byte R { get; private set; }
	}
}