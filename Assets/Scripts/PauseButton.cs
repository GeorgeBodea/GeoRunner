using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI1;


    // Update is called once per frame

    public void Game()
    {
        if (GameIsPaused)
        {
            pauseMenuUI1.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        else
        {
            pauseMenuUI1.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}