using FluentAssertions;
using Xunit;

namespace StringMixerLibrary.Test
{
    public class MixTests
    {
        [Theory]
        [InlineData("abc", "def", "adbecf")]
        [InlineData("abc", "de", "adbec")]
        [InlineData("ab", "def", "adbef")]
        [InlineData("", "def", "def")]
        [InlineData("abc", "", "abc")]
        public void Mixing_TwoStrings_ShouldReturnMixedString(
                    string input1,
                    string input2,
                    string expectedResult)
        {
            //Arrange
            var sut = new StringMixer();

            //Act
            string actual = sut.Mix(input1, input2);

            //Assert
            actual.Should().Be(
                expectedResult,
                $"Mixing \"{input1}\" and \"{input2}\" " +
                $"should return \"{expectedResult}\"");
        }
    }
}