using FluentAssertions;
using Xunit;

namespace CalculatorApp.Domain.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void WhenStartingCalculator_DisplayIsZero()
        {
            //Arrange && Act
            var sut = new Calculator();

            //Assert
            sut.Display.Should().Be(0);
        }

        [Fact]
        public void GivenNewCalculator_WhenIPress1_ThenDisplayIs1()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            sut.Handle('1');

            //Assert
            sut.Display.Should().Be(1);
        }

        [Fact]
        public void GivenNewCalculator_WhenIPress1And0_ThenDisplayIs10()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            sut.Handle('1');
            sut.Handle('0');

            //Assert
            sut.Display.Should().Be(10);
        }

        [Fact]
        public void GivenNewCalculator_WhenIPress1And0AndPlus_ThenDisplayIs10AndFormulaIs10Plus()

        {
            //Arrange
            var sut = new Calculator();

            //Act
            sut.Handle('1');
            sut.Handle('0');
            sut.Handle('+');

            //Assert
            sut.Display.Should().Be(10);
            sut.Formula.Should().Be("10 +");
        }

        [Fact]
        public void GivenNewCalculator_WhenIPress1And0AndPlusAndFive_ThenDisplayIs5AndFormulaIs10Plus()

        {
            //Arrange
            var sut = new Calculator();

            //Act
            sut.Handle('1');
            sut.Handle('0');
            sut.Handle('+');
            sut.Handle('5');

            //Assert
            sut.Display.Should().Be(5);
            sut.Formula.Should().Be("10 +");
        }

        [Fact]
        public void GivenNewCalculator_WhenIPress1And0AndPlusAndFiveAndEquals_ThenDisplayIs15AndFormulaIsEmpty()

        {
            //Arrange
            var sut = new Calculator();

            //Act
            sut.Handle('1');
            sut.Handle('0');
            sut.Handle('+');
            sut.Handle('5');
            sut.Handle('=');

            //Assert
            sut.Display.Should().Be(15);
            sut.Formula.Should().BeEmpty();
        }
    }
}