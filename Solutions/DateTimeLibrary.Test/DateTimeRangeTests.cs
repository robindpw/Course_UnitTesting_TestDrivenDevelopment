using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DateTimeLibrary.Test
{
    public class DateTimeRangeTest
    {
        [Fact]
        public void CreateDateTimeRange_StartDateLaterThanEndDate_ThrowsArgumentException()
        {
            //Arrange
            var function = new Func<DateTimeRange>(() => new DateTimeRange(new DateTime(2000, 01, 01), new DateTime(1999, 01, 01)));

            //Act
            Action act = () => function();

            //Assert
            act.Should()
                .Throw<ArgumentException>(
                    "when the startdate is later than the enddate, an argumentException should be thrown.")
                    .WithMessage("Start date should not be later than end date.");
        }

        [Theory]
        [MemberData(nameof(DateTimeTestCases))]
        //InlineData gaat hier niet, kan geen new DateTime() definiëren in een Attribute
        public void DateInRange_WithGivenParameters_ShouldReturnExpectedResults(DateTime start, DateTime end, DateTime date, bool expectedResult)
        {
            //Arrange
            var sut = new DateTimeRange(start, end);

            //Act
            bool actual = sut.Includes(date);

            //Assert
            actual.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> DateTimeTestCases()
        {
            return new object[][]
            {
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), new DateTime(2000, 1, 1), true },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), new DateTime(2000, 1, 2), true },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), new DateTime(2000, 1, 3), true },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), new DateTime(1999, 12, 31), false },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), new DateTime(2000, 1, 4), false },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), DateTime.MaxValue, false },
                new object[] { new DateTime(2000, 1, 1), new DateTime(2000, 1, 3), DateTime.MinValue, false }
            };
        }
    }
}