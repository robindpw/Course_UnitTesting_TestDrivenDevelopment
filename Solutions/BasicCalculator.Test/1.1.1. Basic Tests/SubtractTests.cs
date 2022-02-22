using Xunit;

namespace BasicCalculator.Test._1._1._1._Basic_Tests
{
    public class SubtractTests
    {
        [Fact]
        public void Subtracting_OneFromOne_ReturnsZero()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 1;
            int expected = 0;

            //Act
            int actual = sut.Subtract(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtracting_TenFromMinusFive_ReturnsMinusFifteen()
        {
            //Arrange
            var sut = new Calculator();
            int x = -5;
            int y = 10;
            int expected = -15;

            //Act
            int actual = sut.Subtract(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtracting_OneFromZero_ReturnsMinusOne()
        {
            //Arrange
            var sut = new Calculator();
            int x = 0;
            int y = 1;
            int expected = -1;

            //Act
            int actual = sut.Subtract(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}