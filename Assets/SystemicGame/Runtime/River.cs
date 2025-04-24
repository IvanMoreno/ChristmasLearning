using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class River : MonoBehaviour
{
    public GameObject waterPrefab;
    public float width = 3;
    public float spawnCadence = 0.01f;
    public float waterParticleLifeTime = 5;

    IEnumerator Start()
    {
        while (Application.isPlaying)
        {
            var position = transform.position + transform.right * Random.Range(-width, width);
            var newWaterParticle = Instantiate(waterPrefab, position, transform.rotation);
            Destroy(newWaterParticle, waterParticleLifeTime);
            yield return new WaitForSeconds(spawnCadence);
        }
    }
}