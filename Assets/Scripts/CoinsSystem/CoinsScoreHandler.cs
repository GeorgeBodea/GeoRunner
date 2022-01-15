using UnityEngine;
using UnityEngine.UI;

public class CoinsScoreHandler : MonoBehaviour
{
    public Text CoinText;

    public int coins;

    // Start is called before the first frame update
    private void Start()
    {
        if (!PlayerPrefs.HasKey("permanent_coins")) PlayerPrefs.SetInt("permanent_coins", 0);
    }

    // Update is called once per frame
    private void Update()
    {
        coins = PlayerPrefs.GetInt("permanent_coins");
        CoinText.text = coins.ToString();
    }
}