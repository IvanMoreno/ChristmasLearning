using ChristmasLearningProject.Runtime.Domain;

namespace ChristmasLearningProject.Runtime.Application
{
    public class Rewind
    {
        readonly Game game;

        public Rewind(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Rewind();
        }
    }
}