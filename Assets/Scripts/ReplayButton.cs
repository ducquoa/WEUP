using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public GameManager gameManager;
    private void Start() 
    {

    }

    public void ReplayLevel()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
            {
                gameManager.RestartGame();
                SceneManager.LoadScene(0);
                
            }
    }

}