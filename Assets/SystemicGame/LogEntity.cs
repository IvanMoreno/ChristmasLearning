using UnityEngine;

public class LogEntity : Entity
{
    protected override string signal { get; }

    public override void Perceive(string stimuli)
    {
        Debug.Log("He percibido el estimulo " + stimuli);
    }
}