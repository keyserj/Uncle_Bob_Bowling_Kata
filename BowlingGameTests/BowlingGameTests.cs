using BowlingGame;
using Xunit;

namespace BowlingGameTests
{
    public class BowlingGameTests
    {
        private Game _game;

        public BowlingGameTests()
        {
            _game = new Game();
        }

        private void RollMany(int rolls, int pinsPerRoll)
        {
            for (int i = 0; i < rolls; i++)
            {
                _game.Roll(pinsPerRoll);
            }
        }

        private void RollSpare()
        {
            _game.Roll(4);
            _game.Roll(6);
        }

        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, _game.Score());
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, _game.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            // Arrange
            RollSpare();

            // Act
            _game.Roll(3);

            // Assert
            RollMany(17, 0);
            Assert.Equal(16, _game.Score());
        }

        [Fact]
        public void TestOneStrike()
        {
            // Arrange
            RollStrike();

            // Act
            _game.Roll(3);
            _game.Roll(4);

            // Assert
            RollMany(17, 0);
            Assert.Equal(24, _game.Score());
        }

        [Fact]
        public void TestPerfectGame()
        {
            // Arrange

            // Act
            RollMany(12, 10);

            // Assert
            Assert.Equal(300, _game.Score());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}