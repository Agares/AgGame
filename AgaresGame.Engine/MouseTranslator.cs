namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Gui;

	using SDL2;

	public class MouseTranslator
	{
		public MouseButtons TranslateButton(uint which)
		{
			switch (which)
			{
				case SDL.SDL_BUTTON_LEFT:
					return MouseButtons.Left;
				case SDL.SDL_BUTTON_RIGHT:
					return MouseButtons.Right;
				case SDL.SDL_BUTTON_MIDDLE:
					return MouseButtons.Middle;
			}

			throw new Exception("Unknown mouse button!");
		}
	}
}