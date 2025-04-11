using UnityEngine;

public class Emitter : MonoBehaviour
{
    public string signal = "";
    
    void Start()
    {
        var nearby = Physics.OverlapSphere(transform.position, 1);
        foreach (var nearbyEntity in nearby)
        {
            nearbyEntity.SendMessage("Perceive", signal);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("Perceive", signal);
    }
}