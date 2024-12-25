using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class Turret : MonoBehaviour
    {
        void Update()
        {
            ShootToEnemy();
        }

        static void ShootToEnemy()
        {
            if (FindObjectOfType<CristalBoat>() == null) return;
            
            FindObjectOfType<CristalBoat>().gameObject.SetActive(false);
        }
    }
}