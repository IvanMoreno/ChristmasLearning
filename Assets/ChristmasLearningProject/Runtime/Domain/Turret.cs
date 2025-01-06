using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        readonly Vector2 position;

        public Turret(Vector2 position, Vector2 facingDirection)
        {
            this.position = position;
        }

        public void Attack(Fleet invaders)
        {
            NearestInvader(invaders).ReceiveDamage();
        }

        Boat NearestInvader(Fleet invaders)
        {
            var nearestInvader = invaders.Members.First();
            foreach (var invader in invaders.Members)
            {
                if (Distance(invader.Position, position) >= Distance(nearestInvader.Position, position))
                    continue;
                
                nearestInvader = invader;
            }

            return nearestInvader;
        }
    }
}