namespace AgaresGame.Engine.Gui
{
	public class ButtonAppearance
	{
		public ButtonAppearance()
		{
			this.Padding = new Padding();
		}

		public IScalableSizedRenderable Background { get; set; }

		public Padding Padding { get; set; }
	}
}