using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        public const float MaxDetectionDistance = 5;
        
        readonly Vector2 position;

        Turret(Vector2 position, Vector2 facingDirection)
        {
            this.position = position;
        }

        public void Attack(Fleet invaders)
        {
            NearestInvader(invaders)?.ReceiveDamage();
        }

        Boat NearestInvader(Fleet invaders) => invaders.Members.OrderBy(DistanceToMe).FirstOrDefault(IsInRange);

        float DistanceToMe(Boat invader) => Distance(invader.Position, position);
        bool IsInRange(Boat invader) => Distance(invader.Position, position) <= MaxDetectionDistance;

        public static Turret Ensemble(Vector2 position, Vector2 facingDirection) => new(position, facingDirection);
    }
}