using UnityEngine;

public class Plant : Entity
{
    public Material burnedMaterial;
    public override void Perceive(string stimuli)
    {
        if (stimuli != "Fire") return;
        
        GetComponent<MeshRenderer>().material = burnedMaterial;

        if (gameObject.GetComponent<Flame>() == null)
        {
            gameObject.AddComponent<Flame>();
            var nearby = Physics.OverlapSphere(transform.position, 1);
            foreach (var nearbyEntity in nearby)
            {
                if (!nearbyEntity.TryGetComponent(typeof(Entity), out var entity)) return;

                entity.SendMessage("Perceive", "Fire");
            }
        }
    }
}