using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}