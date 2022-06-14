using System;
namespace BatalhaNaval
{
	public static class GameMessages
	{
		public const string Menu = @"
======= Batalha Naval =======

Escolha uma opção:
1 - Vs CPU.
2 - Multiplayer
3 - Sair
";


		public const string PlayerNameInputScreen = @"
======= Bem-vindo(a) =======

Digite o nome do jogador(a) ";

		public const string InvalidPlayerName = "⚠ Nome do jogador não pode ser vazio! Digite novamente";


		public const string PlacingShipsScreenRules = @"
======= Inserindo suas embarcações =======

Abaixo temos a tabela das embarcações a serem inseridas.
Cada uma possui um tamanho diferente representado pela quantidade de quadrados no tabuleiro.
Cada jogador pode ter 10 embarcações com a quantidade exatamente igual a tabela a seguir:

-----------------------------------------------
| Sigla | Nome         | Tamanho | Quantidade |
-----------------------------------------------
|  PS   | Porta-Aviões |    5    |     1      |
-----------------------------------------------
|  NT   | Navio-Tanque |    4    |     2      |
-----------------------------------------------
|  DS   | Destroyers   |    3    |     3      |
-----------------------------------------------
|  SB   | Submarinos   |    2    |     4      |
-----------------------------------------------

Pressione uma tecla para continuar...

";

		public const string AvaliableShipsScreen = @"

Embarcações disponíveis para inserir:

-----------------------------------------------
| Sigla | Nome         | Tamanho | Quantidade |
-----------------------------------------------
|  PS   | Porta-Aviões |    5    |   {0}/1      |
-----------------------------------------------
|  NT   | Navio-Tanque |    4    |   {1}/2      |
-----------------------------------------------
|  DS   | Destroyers   |    3    |   {2}/3      |
-----------------------------------------------
|  SB   | Submarinos   |    2    |   {3}/4      |
-----------------------------------------------


";

		public const string ShipTypeMessage = "Digite a sigla da embarcação a ser inserida: ";

		public const string ShipPositionMessage = "Digite a posição da embarcação: Ex: A1A5 ";

	}
}

