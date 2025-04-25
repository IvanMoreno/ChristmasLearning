using UnityEngine;

public class Radio : MonoBehaviour
{
    void Perceive(string stimuli)
    {
        if (stimuli == "Electricity" && GetComponentInChildren<SpriteRenderer>().color != Color.black)
        {
            if (gameObject.GetComponent<Emitter>() != null)
                return;
            
            var newComponent = gameObject.AddComponent<Emitter>();
            newComponent.signal = "Sound";
            newComponent.emissionArea = 5;
            Destroy(newComponent, 0.1f);
        }
        else if (stimuli == "Fire")
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }
    }
}