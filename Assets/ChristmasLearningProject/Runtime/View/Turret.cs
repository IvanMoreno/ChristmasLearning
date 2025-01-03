using System;
using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class Turret : MonoBehaviour
    {
        void Start()
        {
            transform.up = transform.position - Vector3.zero;
        }

        void Update()
        {
            ShootToEnemy();
        }

        void ShootToEnemy()
        {
            if (FindObjectOfType<CristalBoat>() == null) return;
            var distanceToCristalBoat = 
                Vector2.Distance(transform.position, FindObjectOfType<CristalBoat>().transform.position);
                
            if (FindObjectOfType<ShieldBoat>() != null)
            {
                var distanceToShieldBoat =
                    Vector2.Distance(transform.position, FindObjectOfType<ShieldBoat>().transform.position);

                if (distanceToShieldBoat <= distanceToCristalBoat)
                    return;
            }

            if (distanceToCristalBoat >= 5) return;
            
            FindObjectOfType<CristalBoat>().gameObject.SetActive(false);
            FindObjectOfType<GameOverScreen>(true).gameObject.SetActive(true);
        }
    }
}