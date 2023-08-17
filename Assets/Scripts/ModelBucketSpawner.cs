using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBucketSpawner : MonoBehaviour
{
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] GameObject blockPrefab;
    public float spawnRate = 0.7f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            float spawnTIme = Random.Range(spawnRate - 0.5f, spawnRate + 0.5f);
            yield return new WaitForSeconds(spawnTIme);
            Instantiate(blockPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)],
            Quaternion.identity);
        }
    }
}
