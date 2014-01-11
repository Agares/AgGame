namespace AgaresGame.Engine.Utils
{
	using AgaresGame.Engine.Mathematics;

	using SDL2;

	internal class SdlRectUtils
	{
		public static SDL.SDL_Rect FromRectangle(Rectangle rect)
		{
			return new SDL.SDL_Rect { w = rect.Size.X, h = rect.Size.Y, x = rect.Position.X, y = rect.Position.Y };
		}
	}
}