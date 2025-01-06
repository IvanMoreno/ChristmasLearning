using UnityEngine;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class LevelEditor : MonoBehaviour
    {
        [Inject] DiContainer container;
        
        [SerializeField] Turret turretPrefab;
        
        void Update()
        {
            ProcessInput();
        }

        void ProcessInput()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            if (PointerSelection.IsOver("LevelEditorButtons")) return;
            
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            var turret = container.InstantiatePrefab(turretPrefab);
            turret.transform.position = position;
        }
    }
}