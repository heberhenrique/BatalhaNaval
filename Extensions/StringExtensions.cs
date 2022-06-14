using System;
namespace BatalhaNaval.Extensions
{
	public static class StringExtensions
	{
		public static T ToEnum<T>(this string input) where T : Enum
		{
			T response = default;


			if (!string.IsNullOrWhiteSpace(input))
			{
				try
				{
					response = (T)(object)input.ToInt();
				}
				catch (Exception ex)
				{
					_ = ex;
				}
			}

			return response;
		}

		public static int ToInt(this string input)
		{
			int response = 0;

            try
            {
				response = Convert.ToInt32(input);
            }
            catch (Exception ex)
            {
				_ = ex;
            }

			return response;
		}
	}
}

