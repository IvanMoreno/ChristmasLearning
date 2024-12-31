using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Boat
    {
        const int Speed = 10;
        public Vector2 Position { get; private set; }
        
        Vector2 departure;
        Vector2 destination;
        
        public void Move(float deltaTime)
        {
            if (departure.Equals(destination))
                throw new InvalidOperationException("A valid route must be specified first");

            Position += (destination - departure).normalized * (deltaTime * Speed);
            ClampPosition();
        }

        void ClampPosition()
        {
            if (destination.IsGreaterThan(departure) && Position.IsGreaterThan(destination) || 
                departure.IsGreaterThan(destination) && Position.IsLessThan(destination))
                Position = destination;
        }

        public void SetRoute(Vector2 departure, Vector2 destination)
        {
            if (departure.Equals(destination))
                throw new ArgumentException("departure and destination must differ");
            
            this.departure = departure;
            this.destination = destination;
            Position = this.departure;
        }

        public static Boat Cristal() => new();
        public static Boat Shield() => new();

        public void Rewind(float deltaTime) => Move(-deltaTime);
    }
}