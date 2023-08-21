using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float score = 0;
    public float prevScore = 0;
    [SerializeField] private int levelsCompleted = 0;
    [SerializeField] private int Upgrader = 0;
    [SerializeField] private int scoreUpgrader = 20 ;
    private const string LevelsCountFile = "levelsCountFile.txt";

    private class LevelAndScoreCount
    {
        public float Score;
        public int Upgrader;
        public int levelsCompleted;
    }

    private void Start()
    {
        if (File.Exists(LevelsCountFile))
        {

            var jsonString = File.ReadAllText(LevelsCountFile);
            var levelCount = JsonUtility.FromJson<LevelAndScoreCount>(jsonString);


            if (levelCount != null)
            {
                prevScore = levelCount.Score;
                Upgrader = levelCount.Upgrader;
                levelsCompleted = levelCount.levelsCompleted;
            }

            scoreUpgrader += Upgrader;
        }
    }

    private void Update()
    {

        scoreText.text = Mathf.RoundToInt(score).ToString();
        if(score >= scoreUpgrader && SceneManager.GetActiveScene().buildIndex <= 2)
        {
            changeLevel();
        }
    }
    public void AddScore()
    {
        score++;
    }

    private void OnGUI()
    {
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }

    public void changeLevel()
    {
        Upgrader += 20;
        levelsCompleted++;
        
        var updatedCount = new LevelAndScoreCount
        {
            Score = score+prevScore,
            Upgrader = Upgrader,
            levelsCompleted = levelsCompleted,
        };

        var jsonString = JsonUtility.ToJson(updatedCount, true);

        File.WriteAllText(LevelsCountFile, jsonString);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
