using FluentAssertions;
using System;
using Xunit;

namespace BasicCalculator.Test._1._1._3._Theories
{
    public class DivideTests
    {
        [Theory]
        [InlineData(1, 1, 1, "1 / 1 = 1")]
        [InlineData(-5, 10, -0.5, "-5 / 10 = -0.5")]
        public void Dividing_TwoNumbers_ReturnsExpectedResult(int x, int y, double expected, string because)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            double actual = sut.Divide(x, y);

            //Assert
            actual.Should().Be(expected, because);
        }

        [Fact]
        public void Dividing_OneByZero_ReturnsCalculationException()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 0;
            string expectedMessage = "Cannot divide by 0.";
            Action act = () => sut.Divide(x, y);

            //Act && Assert
            act.Should().Throw<CalculationException>("1 / 0 is not possible.")
                .WithMessage(expectedMessage);
        }
    }
}