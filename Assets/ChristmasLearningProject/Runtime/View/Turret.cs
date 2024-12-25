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
            if (FindObjectOfType<ShieldBoat>() != null) return;
            if (FindObjectOfType<CristalBoat>() == null) return;
            
            FindObjectOfType<CristalBoat>().gameObject.SetActive(false);
            FindObjectOfType<GameOverScreen>(true).gameObject.SetActive(true);
        }
    }
}