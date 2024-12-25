using UnityEngine;

namespace ChristmasLearningProject.Runtime.View
{
    public class LevelEditor : MonoBehaviour
    {
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
            Instantiate(turretPrefab, position, Quaternion.identity);
        }
    }
}