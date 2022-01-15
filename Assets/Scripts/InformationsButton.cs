using UnityEngine;

public class InformationsButton : MonoBehaviour
{
    public static bool InformationsAreOff;
    public GameObject informationsMenuUI;


    // Update is called once per frame

    public void Info()
    {
        if (InformationsAreOff)
        {
            informationsMenuUI.SetActive(false);
            Time.timeScale = 1f;
            InformationsAreOff = false;
        }
        else
        {
            informationsMenuUI.SetActive(true);
            Time.timeScale = 0f;
            InformationsAreOff = true;
        }
    }
}