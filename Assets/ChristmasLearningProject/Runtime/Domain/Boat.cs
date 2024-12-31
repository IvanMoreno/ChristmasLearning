using System.Collections;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Boat
    {
        public Vector2 Position { get; private set; }
        
        Vector2 departure;
        Vector2 destination;
        
        public void Move(float deltaTime)
        {
            Position += (destination - Position) * (deltaTime * 10);
        }

        public void SetRoute(Vector2 departure, Vector2 destination)
        {
            this.departure = departure;
            this.destination = destination;
            Position = this.departure;
        }

        public static Boat Cristal() => new();
        public static Boat Shield() => new();
    }
}