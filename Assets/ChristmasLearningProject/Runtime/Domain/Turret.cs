using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        public const float MaxDetectionDistance = 5;
        public const float MaxVisionAngle = 120;
        const float ReloadSeconds = 3;

        readonly Vector2 position;
        readonly Vector2 facingDirection;
        float passedSeconds = ReloadSeconds;

        Turret(Vector2 position, Vector2 facingDirection)
        {
            this.position = position;
            this.facingDirection = facingDirection;
        }

        public void Attack(Fleet invaders, float deltaTime = 1f)
        {
            passedSeconds += deltaTime;
            if (passedSeconds < ReloadSeconds) return;
            passedSeconds = 0;
            
            NearestInvader(invaders)?.ReceiveDamage();
        }

        Boat NearestInvader(Fleet invaders) => invaders.Members.OrderBy(DistanceToMe).FirstOrDefault(IsInRange);
        float DistanceToMe(Boat invader) => Distance(invader.Position, position);
        bool IsInRange(Boat invader) => IsNearEnough(invader) && IsInsideVisionRange(invader);
        bool IsNearEnough(Boat invader) => Distance(invader.Position, position) <= MaxDetectionDistance;
        bool IsInsideVisionRange(Boat invader) => Angle(facingDirection, invader.Position - position) <= MaxVisionAngle;

        public static Turret Ensemble(Vector2 position, Vector2 facingDirection) => new(position, facingDirection);
    }
}