using UnityEngine;
using UnityEngine.Serialization;

namespace ChristmasLearningProject.Runtime.View
{
    public class CaptainFinger : MonoBehaviour
    {
        [SerializeField] CristalBoat cristalBoatPrefab;
        [SerializeField] ShieldBoat shieldBoatPrefab;
        
        Vector2 departure;
        bool definedDeparture;
        bool deployCristalBoat = true;

        void Update()
        {
            ProcessInput();
        }

        void ProcessInput()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            if (PointerSelection.IsOverUI()) return;
            
            if (!definedDeparture)
            {
                departure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                definedDeparture = true;
            }
            else if(FindObjectOfType<CristalBoat>() == null)
            {
                var destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (deployCristalBoat)
                {
                    var boat = Instantiate(cristalBoatPrefab, departure, Quaternion.identity);
                    boat.SendTo(destination);    
                }
                else
                {
                    Instantiate(shieldBoatPrefab, departure, Quaternion.identity);
                }
            }
        }

        public void DeployShieldBoat()
        {
            deployCristalBoat = false;
        }
    }
}