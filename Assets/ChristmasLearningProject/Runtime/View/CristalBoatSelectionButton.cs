using UnityEngine;
using UnityEngine.UI;

namespace ChristmasLearningProject.Runtime.View
{
    public class CristalBoatSelectionButton : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SelectCristalBoat);
        }

        static void SelectCristalBoat() => FindObjectOfType<CaptainFinger>().DeployCristalBoat();
    }
}