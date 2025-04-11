using UnityEngine;

public class LogEmitter : MonoBehaviour
{
    public void Perceive(string stimuli)
    {
        Debug.Log("He percibido el estimulo " + stimuli);
    }
}