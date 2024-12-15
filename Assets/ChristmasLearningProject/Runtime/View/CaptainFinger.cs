using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class CaptainFinger : MonoBehaviour
    {
        [SerializeField] CristalBoat prefab;
        
        Vector2 departure;
        bool definedDeparture;

        void Update()
        {
            ProcessInput();
        }

        void ProcessInput()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            
            if (!definedDeparture)
            {
                departure = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                definedDeparture = true;
            }
            else
            {
                Instantiate(prefab);
            }
        }
    }
}