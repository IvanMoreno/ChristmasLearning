using System;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public string signal = "";

    void Start()
    {
        var nearby = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x);
        foreach (var nearbyEntity in nearby)
        {
            EmitTo(nearbyEntity.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EmitTo(other.gameObject);
    }

    void EmitTo(GameObject nearbyEntity)
    {
        try
        {
            nearbyEntity.SendMessage("Perceive", signal);
        }
        catch (Exception e)
        {
        }
    }

    void Perceive(string stimuli)
    {
        if (signal == "Fire" && stimuli == "Water")
        {
            Destroy(this);
        }
    }
}