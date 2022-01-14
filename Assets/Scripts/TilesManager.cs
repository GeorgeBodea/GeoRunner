using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] easyTilesPrefabs;
    public GameObject[] mediumTilesPrefabs;
    public GameObject[] hardTilesPrefabs;
    public GameObject spawnTilePrefab;
    private float zSpawn = 0;
    private float tileLength = 30;
    private int numberOfTiles = 5;
    private bool tilePointsCollected = false;
    private Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SpawnTile(spawnTilePrefab);
        for(int i=0;i<numberOfTiles;++i)
        {
            SpawnTile(easyTilesPrefabs[Random.Range(0,easyTilesPrefabs.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( (player.transform.position.z > zSpawn - (numberOfTiles * tileLength) - tileLength/2)  && !tilePointsCollected)
        {
            ExitTile();
            tilePointsCollected = true;
        }
        if (player.transform.position.z > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(easyTilesPrefabs[Random.Range(0,easyTilesPrefabs.Length)]);
            DeleteTile();
        }
    }

    public GameObject RandomTile()
    {
        // Need to be implemented after new score system
        GameObject ob = new GameObject();
        return ob;
    }
    
    public void SpawnTile(GameObject tile)
    {
        GameObject newGO = Instantiate(tile, transform.forward*zSpawn, transform.rotation);
        activeTiles.Add(newGO);
        zSpawn += tileLength;
        tilePointsCollected = false;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private void ExitTile()
    {
        switch (activeTiles[0].tag)
        {
            case "EasyTile":
                player.GetComponent<SphereMovement>().addPoints(1);
                break;
            case "MediumTile":
                player.GetComponent<SphereMovement>().addPoints(2);
                break;
            case "HardTile":
                player.GetComponent<SphereMovement>().addPoints(4);
                break;
        }
    }
}
