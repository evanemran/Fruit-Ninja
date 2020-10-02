using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruit;
    public Transform[] spawnpoints;
    public float minDelay = 0.1f;
    public float maxDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits ()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnpoints.Length);
            Transform spawnpoint = spawnpoints[spawnIndex];
            GameObject spawnedFruit = Instantiate(fruit, spawnpoint.position, spawnpoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }
}
