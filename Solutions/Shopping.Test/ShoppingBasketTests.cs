using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Shopping.Test
{
    public class ShoppingBasketTests
    {
        [Fact]
        public void GivenEmptyBasket_WhenItemIsAdded_ThenDisplayShowsExpectedResult()
        {
            //Arrange
            ISoundModule fakeSoundModule = A.Fake<ISoundModule>();
            IPriceCatalog fakePriceCatalog = A.Fake<IPriceCatalog>();

            A.CallTo(() => fakePriceCatalog.GetArticle(1)).Returns(new Article()
            {
                Id = 1,
                Name = "12 Eggs",
                Price = 2.69m
            });

            string expected = "1 x 12 Eggs, 2.69 Euro; Total Amount: 2.69 Euro";
            var sut = new ShoppingBasket(fakeSoundModule, fakePriceCatalog, 0);

            //Act
            sut.AddArticle(1, 0);

            //Assert
            sut.Display.Should().Be(expected);
        }

        [Fact]
        public void GivenShoppingBasket_WhenPriceUpdatedLower_ThenDisplayShowsExpectedResult()
        {
            //Arrange
            ISoundModule fakeSoundModule = A.Fake<ISoundModule>();
            IPriceCatalog fakePriceCatalog = A.Fake<IPriceCatalog>();
            var catalog = new Article[]
            {
                new Article()
                {
                    Id = 1,
                    Name = "12 Eggs",
                    Price = 2.20m
                },
                new Article()
                {
                    Id = 2,
                    Name = "1l Water",
                    Price = 1.50m
                }
            };

            A.CallTo(() => fakePriceCatalog.GetArticle(A<int>._))
                .ReturnsLazily((int id) => catalog.Single(a => a.Id == id));

            string expected = $"2 x 12 Eggs, 4.40 Euro; 5 x 1l Water, 7.50 Euro; Total Amount: 11.90 Euro";
            var sut = new ShoppingBasket(fakeSoundModule, fakePriceCatalog, 0, new ArticleEntry[]
            {
                new ArticleEntry()
                {
                    ArticleId = 1,
                    Count = 2,
                    Name = "12 Eggs",
                    UnitPrice = 2.69m
                },
                new ArticleEntry()
                {
                    ArticleId = 1,
                    Count = 5,
                    Name = "1l Water",
                    UnitPrice = 1.5m
                }
            });

            //Act
            sut.UpdatePrices();

            //Assert
            sut.Display.Should().Be(expected);
            A.CallTo(() => fakeSoundModule.Beep()).MustHaveHappened();
        }

        [Fact]
        public void GivenShoppingBasket_WhenPriceUpdatedHigher_ThenDisplayShowsExpectedResult()
        {
            //Arrange
            ISoundModule fakeSoundModule = A.Fake<ISoundModule>();
            IPriceCatalog fakePriceCatalog = A.Fake<IPriceCatalog>();
            var catalog = new Article[]
            {
                new Article()
                {
                    Id = 1,
                    Name = "12 Eggs",
                    Price = 3.20m
                },
                new Article()
                {
                    Id = 2,
                    Name = "1l Water",
                    Price = 1.50m
                }
            };

            A.CallTo(() => fakePriceCatalog.GetArticle(A<int>._))
                .ReturnsLazily((int id) => catalog.Single(a => a.Id == id));

            string expected = "2 x 12 Eggs, 5.38 Euro; 5 x 1l Water, 7.50 Euro; Total Amount: 12.88 Euro";
            var sut = new ShoppingBasket(fakeSoundModule, fakePriceCatalog, 0, new ArticleEntry[]
            {
                new ArticleEntry()
                {
                    ArticleId = 1,
                    Count = 2,
                    Name = "12 Eggs",
                    UnitPrice = 2.69m
                },
                new ArticleEntry()
                {
                    ArticleId = 1,
                    Count = 5,
                    Name = "1l Water",
                    UnitPrice = 1.5m
                }
            });

            //Act
            sut.UpdatePrices();

            //Assert
            sut.Display.Should().Be(expected);
            A.CallTo(() => fakeSoundModule.Beep()).MustNotHaveHappened();
        }

        [Fact]
        public void GivenShoppingBasket_WhenWeightExceeded_ThenDisplayShowsExpectedResult()
        {
            //Arrange
            ISoundModule fakeSoundModule = A.Fake<ISoundModule>();
            IPriceCatalog fakePriceCatalog = A.Fake<IPriceCatalog>();
            A.CallTo(() => fakePriceCatalog.GetArticle(A<int>._)).Returns(new Article());
            var sut = new ShoppingBasket(fakeSoundModule, fakePriceCatalog, 0.75f);
            string expected = "Allowed weight exceeded, please remove one or more articles.";

            //Act
            sut.AddArticle(0, 1);

            //Assert
            sut.Display.Should().Be(expected);
            A.CallTo(() => fakeSoundModule.Beep()).MustHaveHappened(3, Times.Exactly);
        }
    }
}