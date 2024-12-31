using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class PauseButton : MonoBehaviour
    {
        [Inject] TogglePause controller;
        
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(controller.Execute);
        }
    }
}