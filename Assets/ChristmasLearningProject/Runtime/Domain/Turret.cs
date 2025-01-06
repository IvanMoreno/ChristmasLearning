using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.Vector2;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Turret
    {
        public const float MaxDetectionDistance = 5;
        public const float MaxVisionAngle = 120;
        public const float ReloadSeconds = 3;

        readonly Vector2 position;
        readonly Vector2 facingDirection;
        float passedSeconds = ReloadSeconds;

        Turret(Vector2 position, Vector2 facingDirection)
        {
            this.position = position;
            this.facingDirection = facingDirection;
        }

        public void Attack(Fleet invaders, float deltaTime)
        {
            if (deltaTime < 0)
                throw new ArgumentException("deltaTime must be positive");
            
            passedSeconds += deltaTime;
            if (passedSeconds < ReloadSeconds) return;
            
            var nearestInvader = NearestInvader(invaders);
            if (nearestInvader == null) return;
            
            nearestInvader.ReceiveDamage();
            passedSeconds = 0;
        }

        Boat NearestInvader(Fleet invaders) => invaders.Members.Where(IsAlive).OrderBy(DistanceToMe).FirstOrDefault(IsInRange);
        static bool IsAlive(Boat invader) => invader.IsAlive;
        float DistanceToMe(Boat invader) => Distance(invader.Position, position);
        bool IsInRange(Boat invader) => IsNearEnough(invader) && IsInsideVisionRange(invader);
        bool IsNearEnough(Boat invader) => Distance(invader.Position, position) <= MaxDetectionDistance;
        bool IsInsideVisionRange(Boat invader) => Angle(facingDirection, invader.Position - position) <= MaxVisionAngle;

        public static Turret Ensemble(Vector2 position, Vector2 facingDirection) => new(position, facingDirection);
    }
}