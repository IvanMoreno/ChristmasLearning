using UnityEngine;

public class Flame : Entity
{
    protected override string signal => "Fire";

    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(typeof(Entity), out var entity)) return;

        entity.SendMessage("Perceive", signal);
    }

    public override void Perceive(string stimuli)
    {
        
    }
}