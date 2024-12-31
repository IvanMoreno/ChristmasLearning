namespace ChristmasLearningProject.Runtime.View
{
    public class TogglePause
    {
        readonly Game game;

        public TogglePause(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.IsPaused)
                game.Resume();
            else
                game.Pause();
        }
    }
}