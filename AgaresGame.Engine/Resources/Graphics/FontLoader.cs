namespace AgaresGame.Engine.Resources.Graphics
{
	using System.IO;

	using AgaresGame.Engine.Resources.Loaders;

	public class FontLoader : CachedResourceLoader<Font>
	{
		protected override Font LoadResource(string filename)
		{
			return new Font(Path.Combine("Content", "Fonts", filename));
		}
	}
}