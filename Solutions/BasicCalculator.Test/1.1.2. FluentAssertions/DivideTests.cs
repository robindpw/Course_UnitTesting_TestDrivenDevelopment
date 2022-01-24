using FluentAssertions;
using System;
using Xunit;

namespace BasicCalculator.Test._1._1._2._FluentAssertions
{
    public class DivideTests
    {
        [Fact]
        public void Dividing_OneByOne_ReturnsOne()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 1;
            int expected = 1;

            //Act
            double actual = sut.Divide(x, y);

            //Assert
            actual.Should().Be(expected, $"1 / 1 = 1");
        }

        [Fact]
        public void Dividing_TenByMinusFive_ReturnsMinusPointFive()
        {
            //Arrange
            var sut = new Calculator();
            int x = -5;
            int y = 10;
            double expected = -0.5;

            //Act
            double actual = sut.Divide(x, y);

            //Assert
            actual.Should().Be(expected, $"-5 / 10 = -0.5");
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