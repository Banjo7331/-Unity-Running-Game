using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] GameObject blockPrefab;
    float spawnRate;
    bool a = true;

    private void Start()
    {
        spawnRate = 1;

        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if( a == true)
        {
            spawnRate = 20;
            a = false;
        }else if ( a == false)
        {
            spawnRate = 30;
            a = true;
        }
        
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
