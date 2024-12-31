namespace ChristmasLearningProject.Runtime.View
{
    public class MoveFleet
    {
        readonly Game game;

        CristalBoat cristalBoat;
        ShieldBoat shieldBoat;

        public MoveFleet(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            if (game.IsPaused) return;
            
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
    }
}