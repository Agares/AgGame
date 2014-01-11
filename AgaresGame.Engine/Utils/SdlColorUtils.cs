namespace AgaresGame.Engine.Utils
{
	using AgaresGame.Engine.Graphics;

	using SDL2;

	internal class SdlColorUtils
	{
		public static SDL.SDL_Color FromColor(Color color)
		{
			return new SDL.SDL_Color { a = color.A, r = color.R, g = color.G, b = color.B };
		}
	}
}