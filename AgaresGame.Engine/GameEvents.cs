using System;
using AgaresGame.Engine.Gui;
using AgaresGame.Engine.Mathematics;
using SDL2;

namespace AgaresGame.Engine
{
	public class GameEvents
	{
		private readonly KeyboardTranslator _keyboardTranslator;
		private readonly MouseTranslator _mouseTranslator;

		public event Action<object, EventArgs> Quit;
		public event Action<object, MouseMoveEventArgs> MouseMove;
		public event Action<object, KeyDownEventArgs> KeyDown;
		public event Action<object, ClickEventArgs> Click;

		public GameEvents()
		{
			_keyboardTranslator = new KeyboardTranslator();
			_mouseTranslator = new MouseTranslator();
		}

		public void HandleEvents()
		{
			SDL.SDL_Event ev;
			while (SDL.SDL_PollEvent(out ev) > 0)
			{
				switch (ev.type)
				{
					case SDL.SDL_EventType.SDL_QUIT:
						OnQuit();
						break;
					case SDL.SDL_EventType.SDL_MOUSEMOTION:
						OnMouseMove(new Point2(ev.motion.x, ev.motion.y));
						break;
					case SDL.SDL_EventType.SDL_KEYDOWN:
						OnKeyDown(_keyboardTranslator.TranslateKey(ev.key.keysym.sym), _keyboardTranslator.TranslateModifier(ev.key.keysym.mod));
						break;
					case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
						OnClick(_mouseTranslator.TranslateButton(ev.button.button), new Point2(ev.button.x, ev.button.y));
						break;
				}
			}
		}

		protected virtual void OnKeyDown(Keys key, Modifiers modifier)
		{
			var handler = KeyDown;
			if (handler != null) handler(this, new KeyDownEventArgs(key, modifier));
		}

		protected virtual void OnMouseMove(Point2 position)
		{
			var handler = MouseMove;
			if (handler != null) handler(this, new MouseMoveEventArgs(position));
		}

		protected virtual void OnQuit()
		{
			var handler = Quit;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		protected virtual void OnClick(MouseButtons button, Point2 position)
		{
			var handler = Click;
			if (handler != null) handler(this, new ClickEventArgs(button, position));
		}
	}
}