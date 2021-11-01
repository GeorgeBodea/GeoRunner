using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour
{
    public GameObject completeLevelUI;
    void OnTriggerEnter () 
    {
        Debug.Log("Level Won!");
        completeLevelUI.SetActive(true);
    }
}
