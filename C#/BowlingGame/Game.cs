namespace BowlingGame
{
    public class Game
    {
        private int _currentFrameIndex = 0;
        private readonly Frame[] _frames = new Frame[10];

        public Game()
        {
            for (int i = 0; i < _frames.Length; i++)
            {
                _frames[i] = new Frame();
            }
            _frames[9].TenthFrame = true;
        }

        public void Roll(int pins)
        {
            _frames[_currentFrameIndex].Roll(pins);

            if (_frames[_currentFrameIndex].IsOver())
            {
                _currentFrameIndex++;
            }
        }

        public int Score()
        {
            int score = 0;

            for (int i = 0; i < 10; i++)
            {
                score += _frames[i].Score();
            }

            return score;
        }
    }

    public class Frame
    {
        private readonly int[] _rolls = new int[3];
        private int _currentRoll = 0;

        public bool TenthFrame { get; internal set; }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;

            foreach (int i in _rolls)
            {
                score += i;
            }

            return score;
        }

        public bool IsOver()
        {
            return
                Score() == 10;
        }
    }
}