namespace AgaresGame.Engine.Gui
{
	public class ButtonAppearance
	{
		public IScalableSizedRenderable Background { get; set; }
		public Padding Padding { get; set; }

		public ButtonAppearance()
		{
			Padding = new Padding();
		}
	}
}