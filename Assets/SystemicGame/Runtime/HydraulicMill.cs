using UnityEngine;

public class HydraulicMill : MonoBehaviour
{
    public float rotationSpeed = 10;
    
    void Perceive(string stimuli)
    {
        if (stimuli == "Water")
        {
            var newComponent = gameObject.AddComponent<Emitter>();
            newComponent.signal = "Electricity";
            Destroy(newComponent, 0.1f);
        }
    }
    
    void Update()
    {
        if (gameObject.GetComponent<Emitter>() != null)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
        }
    }
}