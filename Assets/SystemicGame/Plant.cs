using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Material burnedMaterial;
    public Material plantMaterial;

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

    void Update()
    {
        if (gameObject.GetComponent<Emitter>() == null)
        {
            GetComponent<MeshRenderer>().material = plantMaterial;
        }
    }
}