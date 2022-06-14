using System;
using System.Text;
using System.Text.RegularExpressions;
using BatalhaNaval.Enums;
using BatalhaNaval.Extensions;

namespace BatalhaNaval
{
	public static class GameEngine
	{

		/// <summary>
        /// Cria um tabuleiro que é um array bidimensional. 
        /// </summary>
        /// <param name="tamanho">vaso nenhum valor seja passado como parâmetro, o valor padrão é 10</param>
        /// <returns></returns>
		public static string[,] CriarTabuleiro(int tamanho = 10)
		{
			return new string[tamanho, tamanho];
		}

		public static string ShowScreenAndGetInput(string screen, bool toUpper = false)
		{
			var response = string.Empty;
			Console.Clear();
			Console.WriteLine(screen);

			response = Console.ReadLine().Trim();

			if (toUpper)
				response = response.ToUpper();

			return response;
		}

		public static MenuOptions GetMenuOption()
		{
			string option;
			do
			{
				option = ShowScreenAndGetInput(GameMessages.Menu);
			}
			while (!GameValidations.IsMenuOptionValid(option));

			return option.ToEnum<MenuOptions>();
		}

		public static string GetPlayerName(int player)
		{
			string option;
			var invalid = false;
			do
			{
				StringBuilder screen = new StringBuilder();
				screen.AppendLine($"{GameMessages.PlayerNameInputScreen}{player}");

				if (invalid)
				{
					screen.AppendLine();
					screen.AppendLine(GameMessages.InvalidPlayerName);
				}

				option = ShowScreenAndGetInput(screen.ToString());
				invalid = !GameValidations.IsInputValid(option);
			}
			while (invalid);

			return option;
		}

		public static void PlacePlayerShips(List<Player> players)
		{
			ShowScreenAndGetInput(GameMessages.PlacingShipsScreenRules);

            foreach (var player in players)
            {
				var ship = GetShipType(player);
				player.AddShip(GetShipPosition(player, ship));
			}
		}

		public static string GetShipType(Player player)
		{
			string option;
			do
			{
				StringBuilder screen = new StringBuilder();
				var avaliable = string.Format(
					GameMessages.AvaliableShipsScreen,
					player.Ships["PS"],
					player.Ships["NT"],
					player.Ships["DS"],
					player.Ships["SB"]);

				screen.AppendLine(avaliable);
				screen.AppendLine(GameMessages.ShipTypeMessage);


				option = ShowScreenAndGetInput(screen.ToString(), true);
			}
			while (!GameValidations.IsShipTypeValid(option));

			return option;
		}

		public static Ship GetShipPosition(Player player, string ship)
		{
			string option;
			Ship response;
			do
			{
				StringBuilder screen = new StringBuilder();
				var avaliable = string.Format(
					GameMessages.AvaliableShipsScreen,
					player.Ships["PS"],
					player.Ships["NT"],
					player.Ships["DS"],
					player.Ships["SB"]);

				screen.AppendLine(avaliable);
				screen.AppendLine(GameMessages.ShipPositionMessage);


				option = ShowScreenAndGetInput(screen.ToString(), true);
			}
			while (!GameValidations.IsShipPositionValid(option, ship, out response));

			return response;
		}

	}
}

