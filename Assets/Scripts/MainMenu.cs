using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame() 
    { 
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
}
