using System;
using SDL2;

namespace AgaresGame.Engine
{
	public class Game
	{
		public static void InitializeSdl()
		{
			int status = SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
			if (status == -1)
			{
				throw new Exception(SDL.SDL_GetError());
			}

			status = SDL_ttf.TTF_Init();
			if (status == -1)
			{
				throw new Exception(SDL.SDL_GetError());
			}
		}
	}
}