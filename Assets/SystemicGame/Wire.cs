using UnityEngine;

public class Wire : MonoBehaviour
{
    void Perceive(string stimuli)
    {
        if (stimuli == "Electricity")
        {
            gameObject.AddComponent<Emitter>().signal = "Electricity";
            Destroy(gameObject.GetComponent<Emitter>(), 0.1f);
        }
    }

    void Update()
    {
        if (gameObject.GetComponent<Emitter>() != null)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}