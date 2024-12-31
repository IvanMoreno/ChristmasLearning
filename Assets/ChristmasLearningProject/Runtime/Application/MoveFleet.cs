using System.Collections.Generic;

namespace ChristmasLearningProject.Runtime.View
{
    public class MoveFleet
    {
        readonly Game game;
        readonly Sea sea;
        readonly IList<Boat> fleet = new List<Boat>();
               
        public MoveFleet(Game game, Sea sea)
        {
            this.game = game;
            this.sea = sea;
        }

        public void Execute(float deltaTime)
        {
            if (game.IsPaused) return;
            
            MoveAllBoatsInFleet(deltaTime);
            sea.Refresh();
        }

        void MoveAllBoatsInFleet(float deltaTime)
        {
            foreach (var boat in fleet)
            {
                boat.Move(deltaTime);
            }
        }

        public void Add(Boat member) => fleet.Add(member);
    }
}