using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2f;
    public float overDelay = 1f;

    public GameObject gameIsOverUI;

   public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("GameOver1", overDelay);
        }

    }

   

    void GameOver1()
    {
        gameIsOverUI.SetActive(true);
        Invoke("GameOver", restartDelay);
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
