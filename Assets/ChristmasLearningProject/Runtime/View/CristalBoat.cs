using ChristmasLearningProject.Runtime.Domain;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class CristalBoat : MonoBehaviour
    {
        Boat boat;

        public void Configure(Boat boat) => this.boat = boat;
        public void Refresh()
        {
            transform.position = boat.Position;
            
            if (boat.IsAlive) return;
            gameObject.SetActive(false);
            FindObjectOfType<GameOverScreen>(true).gameObject.SetActive(true);
        }
    }
}