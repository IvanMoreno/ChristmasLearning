using UnityEngine;

public class Plant : MonoBehaviour
{
    public Material burnedMaterial;

    public void Perceive(string stimuli)
    {
        var reactiveTo = "Fire";
        if (stimuli != reactiveTo) return;
        
        GetComponent<MeshRenderer>().material = burnedMaterial;

        if (gameObject.GetComponent<Emitter>() == null)
        {
            gameObject.AddComponent<Emitter>().signal = reactiveTo;
        }
    }
}