namespace AgaresGame
{
	using System;

	using AgaresGame.Engine;

	internal class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Game.InitializeSdl();

			using (var window = new Window())
			{
				var game = new MyGame(window);
				game.Run();
			}
		}
	}
}