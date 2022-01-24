using FluentAssertions;
using System;
using Xunit;

namespace BasicCalculator.Test._1._1._3._Theories
{
    public class AddTests
    {
        [Theory]
        [InlineData(1, 1, 2, "1 + 1 = 2")]
        [InlineData(-5, 10, 5, "-5 + 10 = 5")]
        [InlineData(0, 1, 1, "0 + 1 = 1")]
        public void Adding_TwoNumbers_ReturnsExpectedResult(int x, int y, int expected, string because)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            int actual = sut.Add(x, y);

            //Assert
            actual.Should().Be(expected, because);
        }

        [Fact]
        public void Adding_OneToIntMaxValue_ThrowsOverflowException()
        {
            //Arrange
            var sut = new Calculator();
            int x = int.MaxValue;
            int y = 1;

            //Act
            Action act = () => sut.Add(x, y);

            //Assert
            act.Should().Throw<OverflowException>();
        }
    }
}