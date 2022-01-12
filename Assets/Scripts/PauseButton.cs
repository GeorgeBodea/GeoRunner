using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static bool GameIsPaused = false;
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
