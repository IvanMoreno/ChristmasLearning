using UnityEngine;

public class LogEntity : Entity
{
    public override void Perceive(string stimuli)
    {
        Debug.Log("He percibido el estimulo " + stimuli);
    }
}