using System;
namespace BatalhaNaval
{
    /// <summary>
    /// Keeps player information
    /// </summary>
	public class Player
	{
        public int Id { get; }
        public string Name { get; }
        public string[,] Board { get; }
        public Dictionary<string, int> Ships { get; }


        /// <summary>
        /// Create a new player object
        /// </summary>
        /// <param name="boardDimension">indicates dimension. Ex. boardDimension = 10 will result a 10x10 board</param>
        /// <param name="id">Player identification</param>
        /// <param name="name">Player name</param>
        public Player(string name, int id, int boardDimension = 10)
        {
            Board = new string[boardDimension, boardDimension];
            Name = name;
            Id = id;
            Ships = new Dictionary<string, int>();
            Ships.Add("PS", 0);
            Ships.Add("NT", 0);
            Ships.Add("DS", 0);
            Ships.Add("SB", 0);
        }

        public void AddShip(Ship ship)
        {
            if (ship.RowInit == ship.RowEnd)
            {
                for (int i = ship.ColInit; i <= ship.ColEnd; i++)
                {
                    Board[ship.RowInit, i] = ship.ShipType;
                }
            }
            else
            {
                for (int i = ship.RowInit; i <= ship.RowEnd; i++)
                {
                    Board[ship.ColInit, i] = ship.ShipType;
                }
            }

            Ships[ship.ShipType]++;
        }
    }
}

