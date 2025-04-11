using UnityEngine;

public class Emitter : MonoBehaviour
{
    public string signal = "";
    
    void Start()
    {
        var nearby = Physics.OverlapSphere(transform.position, 1);
        foreach (var nearbyEntity in nearby)
        {
            if (!nearbyEntity.TryGetComponent(typeof(Emitter), out var entity)) return;

            entity.SendMessage("Perceive", signal);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(typeof(Emitter), out var entity)) return;

        entity.SendMessage("Perceive", signal);
    }
}