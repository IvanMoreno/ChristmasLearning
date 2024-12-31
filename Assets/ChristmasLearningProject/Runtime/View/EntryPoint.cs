using ChristmasLearningProject.Runtime.Application;
using UnityEngine;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] MoveFleet moveFleet;

        void Update()
        {
            moveFleet.Execute(Time.deltaTime);
        }
    }
}