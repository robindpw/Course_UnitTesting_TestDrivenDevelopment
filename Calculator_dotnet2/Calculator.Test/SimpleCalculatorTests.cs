using System;
using Xunit;

namespace Calculator.Test
{
    public class SimpleCalculatorTests
    {
        [Fact]
        public void Adding_1To1_Returns2()
        {
            var sut = new SimpleCalculator();
            var x = 1;
            var y = 1;
            var expected = 2;

            var actual = sut.Add(x, y);

            Assert.Equal(expected, actual);
        }
    }
}