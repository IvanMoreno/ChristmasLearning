using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Boat
    {
        const int Speed = 10;
        public Vector2 Position { get; private set; }
        public bool IsAlive => lives > 0;

        int lives = 1;
        Route route;

        public void Rewind(float deltaTime) => Move(-deltaTime);

        public void Move(float deltaTime)
        {
            Position += route.Direction * (deltaTime * Speed);
            ClampPosition();
        }

        void ClampPosition()
        {
            if (!route.ReachedDestinationAt(Position)) return;
            
            Position = route.Destination;
        }

        public void SetRoute(Route route)
        {
            this.route = route;
            Position = route.Departure;
        }

        public bool ReachedDeparture() => route.ReachedDepartureAt(Position);

        public void ReceiveDamage()
        {
            lives--;
        }

        public Boat WithLives(int howMuch)
        {
            if (howMuch <= 0)
                throw new ArgumentException("Lives must be greater than 0");
            
            lives = howMuch;
            return this;
        }

        public static Boat Cristal() => new();

        public static Boat Shield() => new();

        public static Boat WithRoute(Route route)
        {
            var result = new Boat();
            result.SetRoute(route);
            return result;
        }
    }
}