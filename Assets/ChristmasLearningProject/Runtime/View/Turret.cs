using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class Turret : MonoBehaviour
    {
        void Update()
        {
            ShootToEnemy();
        }

        void ShootToEnemy()
        {
            if (FindObjectOfType<CristalBoat>() == null) return;
            if (FindObjectOfType<ShieldBoat>() != null)
            {
                var distanceToShieldBoat =
                    Vector2.Distance(transform.position, FindObjectOfType<ShieldBoat>().transform.position);
                var distanceToCristalBoat = 
                    Vector2.Distance(transform.position, FindObjectOfType<CristalBoat>().transform.position);

                if (distanceToShieldBoat <= distanceToCristalBoat)
                    return;
            }
            
            FindObjectOfType<CristalBoat>().gameObject.SetActive(false);
            FindObjectOfType<GameOverScreen>(true).gameObject.SetActive(true);
        }
    }
}