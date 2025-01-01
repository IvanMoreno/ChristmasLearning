using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Boat
    {
        const int Speed = 10;
        public Vector2 Position { get; private set; }
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

        public void SetRoute(Vector2 departure, Vector2 destination)
        {
            if (departure.Equals(destination))
                throw new ArgumentException("departure and destination must differ");

            route = Route.Between(departure, destination);
            Position = route.Departure;
        }

        public static Boat Cristal() => new();
        public static Boat Shield() => new();
    }
}