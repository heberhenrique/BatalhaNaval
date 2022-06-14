using System;
using System.Text.RegularExpressions;

namespace BatalhaNaval
{
	public static class GameValidations
	{
		public const string MenuPattern = @"\b([1-3]{1})\b";
		public const string ShipPositionPattern = @"\b([A-J]{1})(\d{1})([A-J]{1})(\d{1,2})\b";
		public const string ShipTypePattern = @"\b(PS|NT|DS|SB)\b";
		public const string ShotPattern = @"\b([A-J]{1}\d{1,2})\b";
		public const string SingleSquarePattern = @"([A-J]{1}\d{1,2})";
		public static Dictionary<char, int> Rows = new Dictionary<char, int>()
		{
			{'A', 1},
			{'B', 2},
			{'C', 3},
			{'D', 4},
			{'E', 5},
			{'F', 6},
			{'G', 7},
			{'H', 8},
			{'I', 9},
			{'J', 10},
		};

		public static Dictionary<string, int> ShipDistanceSquares = new Dictionary<string, int>()
		{
			{"PS", 4},
			{"NT", 3},
			{"DS", 2},
			{"SB", 1},
		};

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static bool IsInputValid(string input, string pattern = "")
		{
            var isValid = false;

			if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(pattern))
			{
				Regex regex = new(pattern);
				isValid = regex.Match(input).Success;
			}
            else if (string.IsNullOrWhiteSpace(pattern))
			{
				isValid = !string.IsNullOrWhiteSpace(input);
			}

			return isValid;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pattern"></param>
		/// <returns></returns>
		public static bool IsMenuOptionValid(string input)
		{
			return input.Length == 1 && IsInputValid(input, MenuPattern);
		}

		/// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		public static bool IsShipTypeValid(string input)
		{
			return input.Length == 2 && IsInputValid(input, ShipTypePattern);
		}

		public static bool IsShipPositionValid(string input, string ship, out Ship shipResult)
		{
			var response = false;
			shipResult = null;
			if (IsInputValid(input, ShipPositionPattern))
			{
				Regex regex = new(SingleSquarePattern);
				var positions = regex.Matches(input).ToArray();

				var row1 = Rows[positions[0].Value[0]];
				var col1 = Convert.ToInt32(positions[0].Value.Substring(1));

				var row2 = Rows[positions[1].Value[0]];
				var col2 = Convert.ToInt32(positions[1].Value.Substring(1));

				response = IsVerticalOrHorizontal(row1, col1, row2, col2) && IsShipSizeValid(row1, col1, row2, col2, ship);

				if (response)
				{
					shipResult = new Ship();
					shipResult.RowInit = (row1 < row2 ? row1 : row2) -1;
					shipResult.RowEnd = (row1 > row2 ? row1 : row2) -1;

					shipResult.ColInit = (col1 < col2 ? col1 : col2) -1;
					shipResult.ColEnd = (col1 > col2 ? col1 : col2) -1;
				}
			}

			return response;
		}

        public static bool IsVerticalOrHorizontal(int row1, int column1, int row2, int column2)
        {
			return (row1 == row2 || column1 == column2);
        }

		public static bool IsShipSizeValid(int row1, int column1, int row2, int column2, string ship)
		{
			var isValid = false;
			int distance = 0;
			if (row1 == row2)
			{
				distance = column1 - column2;
			}
            else if (column1 == column2)
            {
				distance = row1 - row2;
			}

			if (distance < 0)
				distance = distance * -1;

			isValid = ShipDistanceSquares[ship] == distance;

			return isValid;
		}

	}
}

