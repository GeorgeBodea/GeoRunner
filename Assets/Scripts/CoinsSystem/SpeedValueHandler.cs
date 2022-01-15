using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedValueHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Text CurrentSpeed;

    public float current_speed;

    void Start()
    {
        if(!PlayerPrefs.HasKey("bought_speed")){
            PlayerPrefs.SetFloat("bought_speed", 1F);
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
        current_speed = PlayerPrefs.GetFloat("bought_speed");
        CurrentSpeed.text = current_speed.ToString();
    }
}
