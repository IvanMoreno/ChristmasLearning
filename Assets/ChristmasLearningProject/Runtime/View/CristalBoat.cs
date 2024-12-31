using System.Collections.Generic;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class CristalBoat : MonoBehaviour
    {
        Vector3 destination;

        public void SendTo(Vector2 destination)
        {
            this.destination = destination;
        }

        public void Move()
        {
            transform.position += (destination - transform.position) * (Time.deltaTime * 10);
        }

        public void Refresh()
        {
            
        }
    }
}