using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        public Turret(Vector2 position, Vector2 facingDirection)
        {
            
        }

        public void Attack(Fleet invaders)
        {
            foreach (var invader in invaders.Members)
            {
                invader.ReceiveDamage();
            }
        }
    }
}