using System.Collections.Generic;

namespace ChristmasLearningProject.Runtime.View
{
    public class MoveFleet
    {
        readonly Game game;
        readonly IList<Boat> fleet = new List<Boat>();
        
        CristalBoat cristalBoat;
        ShieldBoat shieldBoat;

        public MoveFleet(Game game)
        {
            this.game = game;
        }

        public void Execute(float deltaTime)
        {
            if (game.IsPaused) return;
            
            foreach (var boat in fleet)
            {
                boat.Move(deltaTime);
            }
            
            cristalBoat?.Move();
            shieldBoat?.Move();
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