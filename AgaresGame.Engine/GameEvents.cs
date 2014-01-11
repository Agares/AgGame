namespace AgaresGame.Engine
{
	using System;

	using AgaresGame.Engine.Gui;
	using AgaresGame.Engine.Mathematics;

	using SDL2;

	public class GameEvents
	{
		private readonly KeyboardTranslator keyboardTranslator;

		private readonly MouseTranslator mouseTranslator;

		public GameEvents()
		{
			this.keyboardTranslator = new KeyboardTranslator();
			this.mouseTranslator = new MouseTranslator();
		}

		public event Action<object, ClickEventArgs> Click;

		public event Action<object, KeyDownEventArgs> KeyDown;

		public event Action<object, MouseMoveEventArgs> MouseMove;

		public event Action<object, EventArgs> Quit;

		public void HandleEvents()
		{
			SDL.SDL_Event ev;
			while (SDL.SDL_PollEvent(out ev) > 0)
			{
				switch (ev.type)
				{
					case SDL.SDL_EventType.SDL_QUIT:
						this.OnQuit();
						break;
					case SDL.SDL_EventType.SDL_MOUSEMOTION:
						this.OnMouseMove(new Point2(ev.motion.x, ev.motion.y));
						break;
					case SDL.SDL_EventType.SDL_KEYDOWN:
						this.OnKeyDown(
							this.keyboardTranslator.TranslateKey(ev.key.keysym.sym), 
							this.keyboardTranslator.TranslateModifier(ev.key.keysym.mod));
						break;
					case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
						this.OnClick(this.mouseTranslator.TranslateButton(ev.button.button), new Point2(ev.button.x, ev.button.y));
						break;
				}
			}
		}

		protected virtual void OnClick(MouseButtons button, Point2 position)
		{
			Action<object, ClickEventArgs> handler = this.Click;
			if (handler != null)
			{
				handler(this, new ClickEventArgs(button, position));
			}
		}

		protected virtual void OnKeyDown(Keys key, Modifiers modifier)
		{
			Action<object, KeyDownEventArgs> handler = this.KeyDown;
			if (handler != null)
			{
				handler(this, new KeyDownEventArgs(key, modifier));
			}
		}

		protected virtual void OnMouseMove(Point2 position)
		{
			Action<object, MouseMoveEventArgs> handler = this.MouseMove;
			if (handler != null)
			{
				handler(this, new MouseMoveEventArgs(position));
			}
		}

		protected virtual void OnQuit()
		{
			Action<object, EventArgs> handler = this.Quit;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}