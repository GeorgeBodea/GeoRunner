using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedShop : MonoBehaviour
{
    // Start is called before the first frame update
    public int available_coins;
    public float available_speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void test() 
    {

        int speedPrice = 1;
        if(!PlayerPrefs.HasKey("bought_speed")){
                PlayerPrefs.SetFloat("bought_speed", 1F);
                Debug.Log("Set initial bough speed");
        }

        if(PlayerPrefs.HasKey("permanent_coins")){
           available_coins = PlayerPrefs.GetInt("permanent_coins");
           if (available_coins >= speedPrice) {

               available_speed = PlayerPrefs.GetFloat("bought_speed");
               PlayerPrefs.SetFloat("bought_speed", available_speed + 0.25F);
               PlayerPrefs.SetInt("permanent_coins", available_coins-speedPrice);
           }
           else Debug.Log("Not enough coins, only: " + available_coins);
        }

    }
        
}
