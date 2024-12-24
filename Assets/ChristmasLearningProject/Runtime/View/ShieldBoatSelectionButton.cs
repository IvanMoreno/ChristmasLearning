using UnityEngine;
using UnityEngine.UI;

namespace ChristmasLearningProject.Runtime.View
{
    public class ShieldBoatSelectionButton : MonoBehaviour
    {
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SelectShieldBoat);
        }

        static void SelectShieldBoat() => FindObjectOfType<CaptainFinger>().DeployShieldBoat();
    }
}