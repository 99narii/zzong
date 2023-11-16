using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private int score;
    private int highScore;
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "����: " + score.ToString();
        highScoreText.text = "�ְ�����: " + highScore.ToString();
    }

    void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
