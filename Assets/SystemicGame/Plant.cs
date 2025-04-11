using UnityEngine;

public class Plant : Entity
{
    public Material burnedMaterial;
    protected override string signal { get; }

    public override void Perceive(string stimuli)
    {
        if (stimuli != "Fire") return;
        
        GetComponent<MeshRenderer>().material = burnedMaterial;

        if (gameObject.GetComponent<Flame>() == null)
        {
            gameObject.AddComponent<Flame>();
        }
    }
}