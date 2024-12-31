using ChristmasLearningProject.Runtime.Domain;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class ShieldBoat : MonoBehaviour
    {
        Boat boat;

        public void Configure(Boat boat) => this.boat = boat;
        public void Refresh() => transform.position = boat.Position;
    }
}