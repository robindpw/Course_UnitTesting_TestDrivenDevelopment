using FluentAssertions;
using Xunit;

namespace BasicCalculator.Test._1._1._2._FluentAssertions
{
    public class MultiplyTests
    {
        [Fact]
        public void Multiplying_OneByOne_ReturnsOne()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 1;
            int expected = 1;

            //Act
            int actual = sut.Multiply(x, y);

            //Assert
            actual.Should().Be(expected, $"1 * 1 = 1");
        }

        [Fact]
        public void Multiplying_TenByMinusFive_ReturnsMinusFifty()
        {
            //Arrange
            var sut = new Calculator();
            int x = -5;
            int y = 10;
            int expected = -50;

            //Act
            int actual = sut.Multiply(x, y);

            //Assert
            actual.Should().Be(expected, $"-5 * 10 = -50");
        }

        [Fact]
        public void Multiplying_OneByZero_ReturnsZero()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 0;
            int expected = 0;

            //Act
            int actual = sut.Multiply(x, y);

            //Assert
            actual.Should().Be(expected, $"1 * 0 = 0");
        }
    }
}