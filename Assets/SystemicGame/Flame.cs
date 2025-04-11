using System;
using UnityEngine;

public class Flame : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other is not Entity entity) return;
        entity.Perceive("Fire");
    }
}