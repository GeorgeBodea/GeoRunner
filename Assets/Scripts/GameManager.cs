using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;


    public GameObject gameIsOverUI;
    private bool gameHasEnded;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("GameOver", restartDelay);
        }
    }

    private void GameOver()
    {
        gameIsOverUI.SetActive(true);
        var score = FindObjectOfType<SphereMovement>().getScore();
        if (score > PlayerPrefs.GetInt("highScore")) PlayerPrefs.SetInt("highScore", score);
        Time.timeScale = 0f;
    }
}