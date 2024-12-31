using UnityEngine;

namespace ChristmasLearningProject.Runtime.Domain
{
    public class Boat
    {
        public readonly string Category;
        public Vector2 Position { get; private set; }
        
        Vector2 departure;
        Vector2 destination;
        Boat(string category) => Category = category;

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

        public static Boat Cristal() => new("Cristal");
        public static Boat Shield() => new("Shield");
    }
}