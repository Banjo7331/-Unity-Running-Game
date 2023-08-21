using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ModelBucketSpawner : MonoBehaviour
{
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject[] blockPrefabs;
    [SerializeField] GameObject floor;
    [SerializeField] TextMeshProUGUI scoreText;
    public float spawnRate = 0.7f;
    public int counterOfModels = 0;
    private Vector3 spawnPosition;
    private int levelsCompleted;
    private const string Shoppt = "Shoop.txt";
    private int coins;
    private bool modell1 = true;
    private bool modell2 = false;



    private class Shop
    {
        public int Coins;
        public bool model1;
        public bool model2;
    }
    private class LevelAndScoreCount
    {
        public float Score;
        public int Upgrader;
        public int levelsCompleted;
    }

    private void Start()
    {
        if (File.Exists(Shoppt))
        {
            var jsonString = File.ReadAllText(Shoppt);
            var shoop = JsonUtility.FromJson<Shop>(jsonString);
            if (shoop != null)
            {
                coins = shoop.Coins;
                modell1 = shoop.model1;
                modell2 = shoop.model2;
            }
        }

        if (File.Exists("levelsCountFile.txt"))
        {
            var jsonString = File.ReadAllText("levelsCountFile.txt");
            var levelCount = JsonUtility.FromJson<LevelAndScoreCount>(jsonString);

            if (levelCount != null)
            {
                levelsCompleted = levelCount.levelsCompleted;
            }
            scoreText.text = Mathf.RoundToInt(levelsCompleted).ToString();
            coins += (int)levelCount.Score;
        }
         
        var saveResults = new Shop
        {
            Coins = coins,
            model1 = modell1,
            model2 = modell2
        };

        var shopToSave = JsonUtility.ToJson(saveResults, true);

        File.WriteAllText(Shoppt, shopToSave);


        spawnPosition = floor.transform.position;
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if(counterOfModels > 20)
        {
            OpenBox();

        }
        else
        {
            ClosedBox();
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, 2) == 0 ? 0 : 1;

            float spawnTIme = Random.Range(spawnRate - 0.5f, spawnRate + 0.5f);
            yield return new WaitForSeconds(spawnTIme);
            Instantiate(blockPrefabs[randomNumber], spawnPoints[Random.Range(0, spawnPoints.Length)],
            Quaternion.identity);
            counterOfModels++;
        }
    }
    private void OpenBox()
    {
        floor.transform.position = new Vector3(-5.2f, -5.8f, 0);
    }
    private void ClosedBox()
    {
        floor.transform.position = spawnPosition;
    }
    public void DeleteDroped()
    {
        counterOfModels--;
    }
}
