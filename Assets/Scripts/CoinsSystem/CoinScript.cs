using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinsScoreHandler GH;
    public AudioClip CoinSound;

    public int rotateSpeed=1;

    // Start is called before the first frame update
    void Start()
    {
        GH = GameObject.Find("DisplayCoinsScore").GetComponent<CoinsScoreHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other) {
        GH.coins++;
        AudioSource.PlayClipAtPoint(CoinSound, transform.position);
        Destroy(gameObject);
    }
}
