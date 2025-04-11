using System;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public string signal = "";
    
    void Start()
    {
        var nearby = Physics.OverlapSphere(transform.position, 1);
        foreach (var nearbyEntity in nearby)
        {
            EmitTo(nearbyEntity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        EmitTo(other);
    }

    void EmitTo(Collider nearbyEntity)
    {
        try
        {
            nearbyEntity.SendMessage("Perceive", signal);
        }
        catch (Exception e)
        {
            
        }
    }

    public void Perceive(string stimuli)
    {
        if (signal == "Fire" && stimuli == "Water")
        {
            Destroy(this);
        }
    }
}