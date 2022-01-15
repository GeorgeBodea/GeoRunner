using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinsScoreHandler GH;
    public AudioClip CoinSound;

    public int rotateSpeed=1;

    private int previous_coins;

    // Start is called before the first frame update
    void Start()
    {
        GH = GameObject.Find("DisplayCoinsScore").GetComponent<CoinsScoreHandler>();

        if(!PlayerPrefs.HasKey("permanent_coins")){
            PlayerPrefs.SetInt("permanent_coins", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GH.coins++;

            // Get previous number of coins
            previous_coins = PlayerPrefs.GetInt("permanent_coins");
            PlayerPrefs.SetInt("permanent_coins", previous_coins+1);

            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
