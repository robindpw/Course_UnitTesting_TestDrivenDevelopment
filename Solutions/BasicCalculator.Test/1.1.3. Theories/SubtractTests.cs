using FluentAssertions;
using Xunit;

namespace BasicCalculator.Test._1._1._3._Theories
{
    public class SubtractTests
    {
        [Theory]
        [InlineData(1, 1, 0, "1 - 1 = 0")]
        [InlineData(-5, 10, -15, "-5 - 10 = -15")]
        [InlineData(0, 1, -1, "0 - 1 = -1")]
        public void Multiplying_Subtract_ReturnsExpectedResult(int x, int y, int expected, string because)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            int actual = sut.Subtract(x, y);

            //Assert
            actual.Should().Be(expected, because);
        }
    }
}