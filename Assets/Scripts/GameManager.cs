using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject gameOverObject;
    private bool isGameOver = false;
    private Vector2 targetPos = new Vector2(660f,1230f);
    private float moveDuration = 0.5f;

    private void Start() {
        gameOverScreen.SetActive(false);
    }
    void Update()
    {
        if (!isGameOver && player == null)
        {
            GameOver();
            StartCoroutine(MoveGameOverObject(new Vector2(660f, 1230f)));
        }
    }

    private IEnumerator MoveGameOverObject(Vector2 targetPosition)
    {
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            gameOverObject.transform.position = Vector2.Lerp(gameOverObject.transform.position, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameOverObject.transform.position = targetPosition;
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
    }
}
