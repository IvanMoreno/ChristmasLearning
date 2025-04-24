using UnityEngine;

public class Turntables : MonoBehaviour
{
    void Perceive(string stimuli)
    {
        if (stimuli == "Electricity")
        {
            gameObject.AddComponent<Emitter>().signal = "Sound";
            Destroy(gameObject.GetComponent<Emitter>(), 0.1f);
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<Emitter>() != null)
        {
            GetComponent<ParticleSystem>().Play();
        }
        else
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }
}