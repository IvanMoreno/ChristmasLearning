using ChristmasLearningProject.Runtime.Domain;

namespace ChristmasLearningProject.Runtime.Application
{
    public class MoveFleet
    {
        readonly Game game;
        readonly Sea sea;
        readonly Fleet fleet;
               
        public MoveFleet(Game game, Sea sea, Fleet fleet)
        {
            this.game = game;
            this.sea = sea;
            this.fleet = fleet;
        }

        public void Execute(float deltaTime)
        {
            if (game.IsPaused) return;
            
            fleet.Move(deltaTime);
            sea.Refresh();
        }
    }
}