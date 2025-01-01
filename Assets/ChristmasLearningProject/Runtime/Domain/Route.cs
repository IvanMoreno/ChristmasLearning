using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public readonly struct Route
    {
        public readonly Vector2 Departure;
        public readonly Vector2 Destination;
        public Vector2 Direction => (Destination - Departure).normalized;

        public Route(Vector2 departure, Vector2 destination)
        {
            if (departure.Equals(destination))
                throw new InvalidOperationException("A valid route must be specified first");

            Departure = departure;
            Destination = destination;
        }

        public bool ReachedDestinationAt(Vector2 position)
        {
            return Destination.IsGreaterThan(Departure) && position.IsGreaterThan(Destination) ||
                   Departure.IsGreaterThan(Destination) && position.IsLessThan(Destination);
        }

        public bool ReachedDepartureAt(Vector2 position)
        {
            return (position * Direction).IsLessThan(Departure * Direction) || position.Equals(Departure);
        }
    }
}