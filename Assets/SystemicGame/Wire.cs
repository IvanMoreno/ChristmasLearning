using UnityEngine;

public class Wire : MonoBehaviour
{
    void Perceive(string stimuli)
    {
        if (stimuli == "Electricity")
        {
            if (gameObject.GetComponent<Emitter>() != null)
                return;
            
            var newComponent = gameObject.AddComponent<Emitter>();
            newComponent.signal = "Electricity";
            Destroy(newComponent, 0.1f);
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<Emitter>() != null)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.gray;
        }
    }
}