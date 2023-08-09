using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameScreen;

    private bool isEndGame = false;
    public TextMeshProUGUI scoreText;

    public void Start() {
        endGameScreen.SetActive(false);    
    }
    void Update()
    {
        int score = GetScoreFromText();
        if (!isEndGame && score == 16)
        {
            EndGameNow();
        }
    }

    void EndGameNow()
    {
        isEndGame = true;
        Time.timeScale = 0;
        endGameScreen.SetActive(true);
    }

    public void RestartGame()
    {
        isEndGame = false;
        Time.timeScale = 1;
        endGameScreen.SetActive(false);
    }
    public int GetScoreFromText()
    {
        if (int.TryParse(scoreText.text, out int score))
            {
                return score;
            }
        return 0;  //if parsing failed
    }
}
