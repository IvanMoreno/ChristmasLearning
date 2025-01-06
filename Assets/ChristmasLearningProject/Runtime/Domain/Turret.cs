using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        readonly Vector2 position;

        Turret(Vector2 position, Vector2 facingDirection)
        {
            this.position = position;
        }

        public void Attack(Fleet invaders)
        {
            NearestInvader(invaders).ReceiveDamage();
        }

        Boat NearestInvader(Fleet invaders) => invaders.Members.OrderBy(DistanceToMe).First();

        float DistanceToMe(Boat invader) => Distance(invader.Position, position);

        public static Turret Ensemble(Vector2 position, Vector2 facingDirection) => new(position, facingDirection);
    }
}