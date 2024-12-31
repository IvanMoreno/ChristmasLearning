using System.Collections.Generic;

namespace ChristmasLearningProject.Runtime.View
{
    public class MoveFleet
    {
        readonly Game game;
        readonly Sea sea;
        readonly IList<Boat> fleet = new List<Boat>();
               
        CristalBoat cristalBoat;
        ShieldBoat shieldBoat;

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
            
            cristalBoat?.Move();
            shieldBoat?.Move();
        }

        void MoveAllBoatsInFleet(float deltaTime)
        {
            foreach (var boat in fleet)
            {
                boat.Move(deltaTime);
            }
        }

        public void AddCristalBoat(CristalBoat boat)
        {
            cristalBoat = boat;
        }

        public void AddShieldBoat(ShieldBoat boat)
        {
            shieldBoat = boat;
        }

        public void Add(Boat member) => fleet.Add(member);
    }
}