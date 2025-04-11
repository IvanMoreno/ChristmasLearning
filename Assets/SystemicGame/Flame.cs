using UnityEngine;

public class Flame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(typeof(Entity), out var entity)) return;

        entity.SendMessage("Perceive", "Fire");
    }
}