using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float score = 0;
    public int levelsCompleted = 0;
    public int scoreUpgrader = 20;



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
        scoreUpgrader += 20;
        levelsCompleted++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
