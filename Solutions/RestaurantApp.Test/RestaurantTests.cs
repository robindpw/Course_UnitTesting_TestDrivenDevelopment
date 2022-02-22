using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace RestaurantApp.Test
{
    public class RestaurantTests
    {
        [Fact]
        public void GettingTableNumberWithHighestPrice_ReturnsExpectedResult()
        {
            //Arrange
            var orders = new Order[]
            {
                new Order() { TableNumber = 1, TotalPrice = 5 },
                new Order() { TableNumber = 1, TotalPrice = 5 },
                new Order() { TableNumber = 2, TotalPrice = 9 },
            };
            IKitchen fakeKitchen = A.Fake<IKitchen>();
            A.CallTo(() => fakeKitchen.GetAllOrders()).Returns(orders);
            var sut = new Restaurant(fakeKitchen);
            int expected = 1;
            //Act
            int actual = sut.GetTableNumberWithHighestTotal();
            //Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void GettingTableNumberWithMostOrders_ReturnsExpectedResult()
        {
            //Arrange
            var orders = new Order[]
            {
                new Order() { TableNumber = 1, TotalPrice = 10 },
                new Order() { TableNumber = 2, TotalPrice = 1 },
                new Order() { TableNumber = 2, TotalPrice = 1 },
            };
            IKitchen fakeKitchen = A.Fake<IKitchen>();
            A.CallTo(() => fakeKitchen.GetAllOrders()).Returns(orders);
            var sut = new Restaurant(fakeKitchen);
            int expected = 2;
            //Act
            int actual = sut.GetTableNumberWithHighestOrderCount();
            //Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void GettingAverageTotalPrice_ReturnsExpectedResult()
        {
            //Arrange
            var orders = new Order[]
            {
                new Order() { TableNumber = 1, TotalPrice = 10 },
                new Order() { TableNumber = 2, TotalPrice = 15 },
                new Order() { TableNumber = 2, TotalPrice = 20 },
            };
            IKitchen fakeKitchen = A.Fake<IKitchen>();
            A.CallTo(() => fakeKitchen.GetAllOrders()).Returns(orders);
            var sut = new Restaurant(fakeKitchen);
            int expected = 15;
            //Act
            decimal actual = sut.GetAverageOrderPrice();
            //Assert
            actual.Should().Be(expected);
        }
    }
}