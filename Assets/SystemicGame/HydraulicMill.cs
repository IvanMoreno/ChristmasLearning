using UnityEngine;

public class HydraulicMill : MonoBehaviour
{
    public float rotationSpeed = 10;
    
    void Perceive(string stimuli)
    {
        if (stimuli == "Water")
        {
            if (gameObject.GetComponent<Emitter>() == null)
                gameObject.AddComponent<Emitter>().signal = "Electricity";
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