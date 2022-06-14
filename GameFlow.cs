using System;
using BatalhaNaval.Enums;

namespace BatalhaNaval
{
	public static class GameFlow
	{
		public static List<Player> players;

		public static void BeginGame()
		{
            switch (GameEngine.GetMenuOption())
            {
				case MenuOptions.OnePlayer:
					OnePlayerFlow();
					break;
				case MenuOptions.TwoPlayer:
					MultiPlayerFlow();
					break;
			}
        }

		public static void OnePlayerFlow()
		{
			Console.Clear();
			Console.WriteLine("Champs");

		}

		public static void MultiPlayerFlow()
		{
			players = GetPlayers();
			GameEngine.PlacePlayerShips(players);
		}

		public static List<Player> GetPlayers()
		{
			List<Player> response = new List<Player>();

			Player player1 = new Player(GameEngine.GetPlayerName(1), 1);
			response.Add(player1);

			Player player2 = new Player(GameEngine.GetPlayerName(2), 2);
			response.Add(player2);

			return response;
		}
	}
}

