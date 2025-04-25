using UnityEngine;

public class Dancer : MonoBehaviour
{
    void Perceive(string stimuli)
    {
        if (stimuli == "Sound")
        {
            if (gameObject.GetComponent<Emitter>() != null)
                return;
            
            var newComponent = gameObject.AddComponent<Emitter>();
            newComponent.signal = "Fire";
            Destroy(newComponent, 0.1f);
        }
    }
    
    void Update()
    {
        if (gameObject.GetComponent<Emitter>() != null)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
        }
    }
}