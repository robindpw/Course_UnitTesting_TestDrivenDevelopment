using Xunit;

namespace BasicCalculator.Test._1._1._1._Basic_Tests
{
    public class AddTests
    {
        [Fact]
        public void Adding_OneToOne_ReturnsTwo()
        {
            //Arrange
            var sut = new Calculator(); // sut stands for System Under Test
            int x = 1;
            int y = 1;
            int expected = 2; //Always use a specific expected result (i.e. never calculate this)

            //Act
            int actual = sut.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Adding_TenToMinusFive_ReturnsFive()
        {
            //Arrange
            var sut = new Calculator();
            int x = -5;
            int y = 10;
            int expected = 5;

            //Act
            int actual = sut.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Adding_OneToZero_ReturnsOne()
        {
            //Arrange
            var sut = new Calculator();
            int x = 1;
            int y = 0;
            int expected = 1;
            //Act
            int actual = sut.Add(x, y);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}