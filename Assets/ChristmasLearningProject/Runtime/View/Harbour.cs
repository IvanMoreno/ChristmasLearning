using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class Harbour : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent(out CristalBoat boat))
                return;

            FindObjectOfType<WinScreen>(true).gameObject.SetActive(true);
        }
    }
}