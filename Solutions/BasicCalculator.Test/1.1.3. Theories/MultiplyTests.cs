using FluentAssertions;
using Xunit;

namespace BasicCalculator.Test._1._1._3._Theories
{
    public class MultiplyTests
    {
        [Theory]
        [InlineData(1, 1, 1, "1 * 1 = 1")]
        [InlineData(-5, 10, -50, "-5 * 10 = -50")]
        [InlineData(0, 1, 0, "0 * 1 = 0")]
        public void Multiplying_TwoNumbers_ReturnsExpectedResult(int x, int y, int expected, string because)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            int actual = sut.Multiply(x, y);

            //Assert
            actual.Should().Be(expected, because);
        }
    }
}