using UnityEngine;

public class Flame : MonoBehaviour
{
    public Material dfasfasfs;

    void Update()
    {
        if (gameObject.GetComponent<Emitter>() == null)
        {
            GetComponent<MeshRenderer>().material = dfasfasfs;
        }
    }
}