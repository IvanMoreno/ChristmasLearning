using UnityEngine;
using UnityEngine.UI;

namespace ChristmasLearningProject.Runtime.View
{
    public class PauseButton : MonoBehaviour
    {
        void Start()
        {
            Time.timeScale = 1;
            GetComponent<Button>().onClick.AddListener(() => Time.timeScale = 0);
        }
    }
}