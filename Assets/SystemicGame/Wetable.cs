using UnityEngine;

public class Wetable : MonoBehaviour
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