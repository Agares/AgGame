using AgaresGame.Engine.Graphics;
using AgaresGame.Engine.Mathematics;

namespace AgaresGame.Engine.Gui
{
	public class Button : ISizedRenderable
	{
		private readonly GameEvents _gameEvents;
		private readonly ButtonAppearance _appearance;
		private readonly ISizedRenderable _content;
		private Point2 _position;

		public delegate void ClickDelegate(object sender, ClickDelegateArgs args);
		public event ClickDelegate Click;
		
		public Vector2 Size
		{
			get
			{
				return new Vector2
					(
					_content.Size.X + _appearance.Padding.Right + _appearance.Padding.Left,
					_content.Size.Y + _appearance.Padding.Bottom + _appearance.Padding.Bottom
					);
			}
		}

		public Button(GameEvents gameEvents, ButtonAppearance appearance, ISizedRenderable content)
		{
			_gameEvents = gameEvents;
			_appearance = appearance;
			_content = content;

			InitializeEvents();
		}

		private void InitializeEvents()
		{
			_gameEvents.Click += (o, args) =>
			{
				if (new Rectangle(_position, Size).Contains(args.Position))
				{
					OnClick(new ClickDelegateArgs(args.Button));
				}
			};
		}

		public void Render(RenderContext context, Point2 position)
		{
			_position = position;

			var contentSize = _content.Size;
			var paddedContentSize = new Vector2(contentSize.X + _appearance.Padding.Left + _appearance.Padding.Right, contentSize.Y + _appearance.Padding.Top + _appearance.Padding.Bottom);

			_appearance.Background.RenderScaled(context, new Rectangle(position, paddedContentSize));
			context.Render(_content, position + new Vector2(_appearance.Padding.Left, _appearance.Padding.Top));
		}

		protected virtual void OnClick(ClickDelegateArgs args)
		{
			var handler = Click;
			if (handler != null) handler(this, args);
		}
	}
}