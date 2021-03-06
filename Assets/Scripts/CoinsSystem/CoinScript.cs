using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinsScoreHandler GH;
    public AudioClip CoinSound;

    public int rotateSpeed = 1;

    private int previous_coins;


    // Start is called before the first frame update
    private void Start()
    {
        GH = GameObject.Find("DisplayCoinsScore").GetComponent<CoinsScoreHandler>();
    }

    // Update is called once per frame
    private void Update()
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
            PlayerPrefs.SetInt("permanent_coins", previous_coins + 1);

            AudioSource.PlayClipAtPoint(CoinSound, transform.position, 0.3F);
            Destroy(gameObject);
        }
    }
}