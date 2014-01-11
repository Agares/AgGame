namespace AgaresGame.Engine.Gui
{
	using AgaresGame.Engine.Graphics;
	using AgaresGame.Engine.Mathematics;

	public class Button : ISizedRenderable
	{
		private readonly ButtonAppearance appearance;

		private readonly ISizedRenderable content;

		private readonly GameEvents gameEvents;

		private Point2 position;

		public Button(GameEvents gameEvents, ButtonAppearance appearance, ISizedRenderable content)
		{
			this.gameEvents = gameEvents;
			this.appearance = appearance;
			this.content = content;

			this.InitializeEvents();
		}

		public delegate void ClickDelegate(object sender, ClickDelegateArgs args);

		public event ClickDelegate Click;

		public Vector2 Size
		{
			get
			{
				return new Vector2(
					this.content.Size.X + this.appearance.Padding.Right + this.appearance.Padding.Left, 
					this.content.Size.Y + this.appearance.Padding.Bottom + this.appearance.Padding.Bottom);
			}
		}

		public void Render(RenderContext context, Point2 renderPosition)
		{
			this.position = renderPosition;

			Vector2 contentSize = this.content.Size;
			var paddedContentSize = new Vector2(
				contentSize.X + this.appearance.Padding.Left + this.appearance.Padding.Right, 
				contentSize.Y + this.appearance.Padding.Top + this.appearance.Padding.Bottom);

			this.appearance.Background.RenderScaled(context, new Rectangle(renderPosition, paddedContentSize));
			context.Render(this.content, renderPosition + new Vector2(this.appearance.Padding.Left, this.appearance.Padding.Top));
		}

		protected virtual void OnClick(ClickDelegateArgs args)
		{
			ClickDelegate handler = this.Click;
			if (handler != null)
			{
				handler(this, args);
			}
		}

		private void InitializeEvents()
		{
			this.gameEvents.Click += (o, args) =>
				{
					if (new Rectangle(this.position, this.Size).Contains(args.Position))
					{
						this.OnClick(new ClickDelegateArgs(args.Button));
					}
				};
		}
	}
}