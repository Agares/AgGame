using System.Diagnostics;
using SDL2;

namespace AgaresGame.Engine
{
	internal class KeyboardTranslator
	{
		internal Keys TranslateKey(SDL.SDL_Keycode keysym)
		{
			switch (keysym)
			{
				case SDL.SDL_Keycode.SDLK_0:
					return Keys.K0;
				case SDL.SDL_Keycode.SDLK_1:
					return Keys.K1;
				case SDL.SDL_Keycode.SDLK_2:
					return Keys.K2;
				case SDL.SDL_Keycode.SDLK_3:
					return Keys.K3;
				case SDL.SDL_Keycode.SDLK_4:
					return Keys.K4;
				case SDL.SDL_Keycode.SDLK_5:
					return Keys.K5;
				case SDL.SDL_Keycode.SDLK_6:
					return Keys.K6;
				case SDL.SDL_Keycode.SDLK_7:
					return Keys.K7;
				case SDL.SDL_Keycode.SDLK_8:
					return Keys.K8;
				case SDL.SDL_Keycode.SDLK_9:
					return Keys.K9;
				case SDL.SDL_Keycode.SDLK_BACKSLASH:
					return Keys.BackSlash;
				case SDL.SDL_Keycode.SDLK_MINUS:
					return Keys.Minus;
				case SDL.SDL_Keycode.SDLK_EQUALS:
					return Keys.Equals;
				case SDL.SDL_Keycode.SDLK_BACKSPACE:
					return Keys.Backspace;
				case SDL.SDL_Keycode.SDLK_q:
					return Keys.Q;
				case SDL.SDL_Keycode.SDLK_w:
					return Keys.W;
				case SDL.SDL_Keycode.SDLK_e:
					return Keys.E;
				case SDL.SDL_Keycode.SDLK_r:
					return Keys.R;
				case SDL.SDL_Keycode.SDLK_t:
					return Keys.T;
				case SDL.SDL_Keycode.SDLK_y:
					return Keys.Y;
				case SDL.SDL_Keycode.SDLK_u:
					return Keys.U;
				case SDL.SDL_Keycode.SDLK_i:
					return Keys.I;
				case SDL.SDL_Keycode.SDLK_o:
					return Keys.O;
				case SDL.SDL_Keycode.SDLK_p:
					return Keys.P;
				case SDL.SDL_Keycode.SDLK_a:
					return Keys.A;
				case SDL.SDL_Keycode.SDLK_s:
					return Keys.S;
				case SDL.SDL_Keycode.SDLK_d:
					return Keys.D;
				case SDL.SDL_Keycode.SDLK_f:
					return Keys.F;
				case SDL.SDL_Keycode.SDLK_g:
					return Keys.G;
				case SDL.SDL_Keycode.SDLK_h:
					return Keys.H;
				case SDL.SDL_Keycode.SDLK_j:
					return Keys.J;
				case SDL.SDL_Keycode.SDLK_k:
					return Keys.K;
				case SDL.SDL_Keycode.SDLK_l:
					return Keys.L;
				case SDL.SDL_Keycode.SDLK_z:
					return Keys.Z;
				case SDL.SDL_Keycode.SDLK_x:
					return Keys.X;
				case SDL.SDL_Keycode.SDLK_c:
					return Keys.C;
				case SDL.SDL_Keycode.SDLK_v:
					return Keys.V;
				case SDL.SDL_Keycode.SDLK_b:
					return Keys.B;
				case SDL.SDL_Keycode.SDLK_n:
					return Keys.N;
				case SDL.SDL_Keycode.SDLK_m:
					return Keys.M;
				case SDL.SDL_Keycode.SDLK_LEFTBRACKET:
					return Keys.BracketOpen;
				case SDL.SDL_Keycode.SDLK_RIGHTBRACKET:
					return Keys.BracketClose;
				case SDL.SDL_Keycode.SDLK_COLON:
					return Keys.Colon;
				case SDL.SDL_Keycode.SDLK_QUOTE:
					return Keys.SingleQuote;
				case SDL.SDL_Keycode.SDLK_COMMA:
					return Keys.Comma;
				case SDL.SDL_Keycode.SDLK_PERIOD:
					return Keys.Period;
				case SDL.SDL_Keycode.SDLK_SLASH:
					return Keys.Slash;
				case SDL.SDL_Keycode.SDLK_DELETE:
					return Keys.Delete;
				case SDL.SDL_Keycode.SDLK_HOME:
					return Keys.Home;
				case SDL.SDL_Keycode.SDLK_END:
					return Keys.End;
				case SDL.SDL_Keycode.SDLK_PAGEUP:
					return Keys.PageUp;
				case SDL.SDL_Keycode.SDLK_PAGEDOWN:
					return Keys.PageDown;
				case SDL.SDL_Keycode.SDLK_UP:
					return Keys.Up;
				case SDL.SDL_Keycode.SDLK_LEFT:
					return Keys.Left;
				case SDL.SDL_Keycode.SDLK_RIGHT:
					return Keys.Right;
				case SDL.SDL_Keycode.SDLK_DOWN:
					return Keys.Down;
				case SDL.SDL_Keycode.SDLK_ALTERASE:
					return Keys.Tilde;
				case SDL.SDL_Keycode.SDLK_ESCAPE:
					return Keys.Escape;
				case SDL.SDL_Keycode.SDLK_F1:
					return Keys.F1;
				case SDL.SDL_Keycode.SDLK_F2:
					return Keys.F2;
				case SDL.SDL_Keycode.SDLK_F3:
					return Keys.F3;
				case SDL.SDL_Keycode.SDLK_F4:
					return Keys.F4;
				case SDL.SDL_Keycode.SDLK_F5:
					return Keys.F5;
				case SDL.SDL_Keycode.SDLK_F6:
					return Keys.F6;
				case SDL.SDL_Keycode.SDLK_F7:
					return Keys.F7;
				case SDL.SDL_Keycode.SDLK_F8:
					return Keys.F8;
				case SDL.SDL_Keycode.SDLK_F9:
					return Keys.F9;
				case SDL.SDL_Keycode.SDLK_F10:
					return Keys.F10;
				case SDL.SDL_Keycode.SDLK_F11:
					return Keys.F11;
				case SDL.SDL_Keycode.SDLK_F12:
					return Keys.F12;
			}

			Debug.WriteLine("Unsupported keycode");
			return Keys.A;
		}

		public Modifiers TranslateModifier(SDL.SDL_Keymod mod)
		{
			switch (mod)
			{
				case SDL.SDL_Keymod.KMOD_NONE:
					return Modifiers.None;
				case SDL.SDL_Keymod.KMOD_LALT:
					return Modifiers.LAlt;
				case SDL.SDL_Keymod.KMOD_LCTRL:
					return Modifiers.LCtrl;
				case SDL.SDL_Keymod.KMOD_LSHIFT:
					return Modifiers.LShift;
				case SDL.SDL_Keymod.KMOD_RALT:
					return Modifiers.RAlt;
				case SDL.SDL_Keymod.KMOD_RCTRL:
					return Modifiers.RCtrl;
				case SDL.SDL_Keymod.KMOD_RSHIFT:
					return Modifiers.RShift;
			}
			Debug.WriteLine("Unsupported modifier");
			return Modifiers.None;
		}
	}
}