using UnityEngine;
using UnityEngine.UI;

namespace ChristmasLearningProject.Runtime.View
{
    public class PauseButton : MonoBehaviour
    {
        void Start()
        {
            Time.timeScale = 1;
            GetComponent<Button>().onClick.AddListener(TogglePause);
        }

        static void TogglePause()
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        }
    }
}