using System;
using Xunit;

namespace BasicCalculator.Test._1._1._1._Basic_Tests
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
            Assert.Equal(expected, actual);
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
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dividing_OneByZero_ReturnsCalculationException()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 0;
            string expectedMessage = "Cannot divide by 0.";
            void act() => sut.Divide(x, y);

            //Act && Assert
            CalculationException exception = Assert.Throws<CalculationException>(act);
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}