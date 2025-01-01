using ChristmasLearningProject.Runtime.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class FastForwardButton : MonoBehaviour
    {
        [Inject] ChangeTimeDirection controller;
        
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(controller.FastForward);
        }
    }
}