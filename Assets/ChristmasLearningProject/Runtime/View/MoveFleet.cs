namespace ChristmasLearningProject.Runtime.View
{
    public class MoveFleet
    {
        CristalBoat cristalBoat;
        ShieldBoat shieldBoat;
        
        public void Execute()
        {
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