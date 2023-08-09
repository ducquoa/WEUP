using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int currentScore = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}