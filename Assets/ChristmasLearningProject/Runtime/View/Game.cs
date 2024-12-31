using System;

namespace ChristmasLearningProject.Runtime.View
{
    public class Game
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            if (IsPaused)
                throw new InvalidOperationException("Game is already paused");

            IsPaused = true;
        }

        public void Resume()
        {
            if (!IsPaused)
                throw new InvalidOperationException("Game is not paused");
            
            IsPaused = false;
        }
    }
}