using FakeItEasy;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Football.Service.Test
{
    public class PlayerServiceTests
    {
        public PlayerServiceTests()
        {
        }

        [Fact]
        public void GetTopPlayer_ReturnsExpectedPlayer()
        {
            //Arrange
            var repo = A.Fake<IPlayerRepository>();
            var expectedPlayer = new Player()
            {
                Name = "Thibault",
                Goals = 100,
                MiniFootBaller = true
            };
            var players = new List<Player>()
            {
                expectedPlayer,
                new Player()
                {
                    Name = "Vincent Kompany",
                    Goals = 2
                }
            };
            A.CallTo(() => repo.GetPlayers(true)).Returns(new List<Player>() { expectedPlayer });

            var sut = new PlayerService(repo);

            //Act
            var actual = sut.GetTopMiniFootballPlayer();

            //Assert
            actual.Should().Be(expectedPlayer);
        }

        [Fact]
        public void UpdatingScore_CallsRepository()
        {
            //Arrange
            var repo = A.Fake<IPlayerRepository>();
            var sut = new PlayerService(repo);

            //Act
            sut.UpdateScore("Shakir", 5);

            //Assert
            A.CallTo(() => repo.UpdateScore("Shakir", 5)).MustHaveHappened();
        }
    }
}