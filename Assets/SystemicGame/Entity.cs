using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected virtual string signal => "";
    void Start()
    {
        var nearby = Physics.OverlapSphere(transform.position, 1);
        foreach (var nearbyEntity in nearby)
        {
            if (!nearbyEntity.TryGetComponent(typeof(Entity), out var entity)) return;

            entity.SendMessage("Perceive", signal);
        }
    }

    public abstract void Perceive(string stimuli);
}