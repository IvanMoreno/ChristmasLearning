using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class CaptainFinger : MonoBehaviour
    {
        [SerializeField] CristalBoat cristalBoatPrefab;
        [SerializeField] ShieldBoat shieldBoatPrefab;
        
        Vector2 departure;
        bool definedDeparture;
        bool deployCristalBoat = true;
        int cristalBoatsInStock = 1;
        int shieldBoatsInStock = 1;

        void Update()
        {
            ProcessInput();
        }

        void ProcessInput()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            if (PointerSelection.IsOverAnyUI()) return;
            
            if (!definedDeparture)
            {
                departure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                definedDeparture = true;
            }
            else if(HasBoatInStock())
            {
                var destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (deployCristalBoat)
                {
                    var boat = Instantiate(cristalBoatPrefab, departure, Quaternion.identity);
                    boat.SendTo(destination);
                    cristalBoatsInStock--;
                }
                else
                {
                    Instantiate(shieldBoatPrefab, departure, Quaternion.identity);
                    shieldBoatsInStock--;
                }
            }
        }

        bool HasBoatInStock()
        {
            if (deployCristalBoat && cristalBoatsInStock > 0)
                return true;

            if (!deployCristalBoat && shieldBoatsInStock > 0)
                return true;

            return false;
        }

        public void DeployShieldBoat()
        {
            deployCristalBoat = false;
        }
    }
}