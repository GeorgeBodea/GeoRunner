using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
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