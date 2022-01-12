using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;


    public GameObject gameIsOverUI;

   public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("GameOver",restartDelay);
        }

    }

   

    void GameOver()
    {
        gameIsOverUI.SetActive(true);
        Time.timeScale = 0f;
    }


}
