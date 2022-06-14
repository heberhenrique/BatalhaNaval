using System;
using BatalhaNaval;
using FluentAssertions;
using Xunit;

namespace BatalhaNavalTests
{
	public class ValidationTests
	{
		[Theory]
        [InlineData("A1A5", "PS")]
		public void TestingValidShipPositionInputs(string input, string ship)
		{
			var result = GameValidations.IsShipPositionValid(input, ship);
			result.Should().BeTrue();
		}
	}
}

