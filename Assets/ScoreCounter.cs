using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float score = 0;



    private void Update()
    {
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
    public void AddScore()
    {
        score++;
    }

    private void OnGUI()
    {
        scoreText.text = Mathf.RoundToInt(score).ToString();
    }
}
