using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public readonly struct Route
    {
        public readonly Vector2 Departure;
        public readonly Vector2 Destination;
        public Vector2 Direction => (Destination - Departure).normalized;

        Route(Vector2 departure, Vector2 destination)
        {
            if (departure.Equals(destination))
                throw new InvalidOperationException("departure and destination must be different");

            Departure = departure;
            Destination = destination;
        }

        public bool ReachedDestinationAt(Vector2 position) 
            => (position * Direction).IsGreaterThan(Destination * Direction) || position.Equals(Destination);

        public bool ReachedDepartureAt(Vector2 position) 
            => (position * Direction).IsLessThan(Departure * Direction) || position.Equals(Departure);

        public static Route Between(Vector2 departure, Vector2 destination) => new(departure, destination);
    }
}