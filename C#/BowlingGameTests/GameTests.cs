using BowlingGame;
using Xunit;

namespace BowlingGameTests
{
    public class GameTests
    {
        private Game _game;

        public GameTests()
        {
            _game = new Game();
        }

        private void RollMany(int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }

        [Fact]
        public void All_Gutters_Scores_0()
        {
            // Act

            // Assert
            RollMany(0, 20);

            // Assert
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void All_Ones_Scores_20()
        {
            // Arrange

            // Act
            RollMany(1, 20);

            // Assert
            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void Spare_Doubles_Next_Roll()
        {
            // Arrange
            _game.Roll(4);
            _game.Roll(6);

            // Act
            _game.Roll(3);

            // Assert
            Assert.Equal(16, _game.Score());
        }
    }
}