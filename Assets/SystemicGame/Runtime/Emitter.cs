using System;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public string signal = "";
    public float emissionArea = 0;

    void Start()
    {
        emissionArea = emissionArea == 0 ? transform.localScale.x : emissionArea;
        var nearby = Physics2D.OverlapCircleAll(transform.position, emissionArea);
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
        nearbyEntity.SendMessage("Perceive", signal, SendMessageOptions.DontRequireReceiver);
    }

    void Perceive(string stimuli)
    {
        if (signal == "Fire" && stimuli == "Water")
        {
            Destroy(this);
        }
    }
}