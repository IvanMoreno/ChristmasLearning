using UnityEngine;

public class Plant : Entity
{
    public Material burnedMaterial;
    public override void Perceive(string stimuli)
    {
        if (stimuli != "Fire") return;
        
        GetComponent<MeshRenderer>().material = burnedMaterial;
        
        if (gameObject.GetComponent<Flame>() == null)
            gameObject.AddComponent<Flame>();
    }
}