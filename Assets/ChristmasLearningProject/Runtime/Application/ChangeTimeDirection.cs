using ChristmasLearningProject.Runtime.Domain;

namespace ChristmasLearningProject.Runtime.Application
{
    public class ChangeTimeDirection
    {
        readonly Game game;

        public ChangeTimeDirection(Game game)
        {
            this.game = game;
        }

        public void Rewind() => game.Rewind();
        public void FastForward() => game.FastForward();
    }
}