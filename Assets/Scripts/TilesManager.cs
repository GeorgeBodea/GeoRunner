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
    private Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SpawnTile(spawnTilePrefab);
        for(int i=0;i<numberOfTiles;++i)
        {
            SpawnTile(RandomTile());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(RandomTile());
            DeleteTile();
        }
    }

    public GameObject RandomTile()
    {
        int randomChance = Random.Range(1, 100);
        if (zSpawn < 200)
        {
            // 90 10 0
            if (randomChance <= 90)
            {
                return easyTilesPrefabs[Random.Range(0, easyTilesPrefabs.Length)];
            }
            return mediumTilesPrefabs[Random.Range(0, mediumTilesPrefabs.Length)];
        }
         if (zSpawn >= 200 && zSpawn <= 400)
        {
            // 40 30 30
            if (randomChance <= 40)
            {
                return easyTilesPrefabs[Random.Range(0, easyTilesPrefabs.Length)];
            }
            if(randomChance<=70)
            {
                return mediumTilesPrefabs[Random.Range(0, mediumTilesPrefabs.Length)];
            }
            return hardTilesPrefabs[Random.Range(0, hardTilesPrefabs.Length)];
        }
        if (zSpawn > 400 && zSpawn <= 600)
        {
            // 10 40 50
            if (randomChance <= 10)
            {
                return easyTilesPrefabs[Random.Range(0, easyTilesPrefabs.Length)];
            }
            if(randomChance<=50)
            {
                return mediumTilesPrefabs[Random.Range(0, mediumTilesPrefabs.Length)];
            }
            return hardTilesPrefabs[Random.Range(0, hardTilesPrefabs.Length)];
        }
        if(zSpawn > 600 && zSpawn <= 800)
        {
            // 0 20 80
            if(randomChance<=20)
            {
                return mediumTilesPrefabs[Random.Range(0, mediumTilesPrefabs.Length)];
            }
            return hardTilesPrefabs[Random.Range(0, hardTilesPrefabs.Length)];
        }
        // 0 0 100
        return hardTilesPrefabs[Random.Range(0, hardTilesPrefabs.Length)];
    }
    
    private void SpawnTile(GameObject tile)
    {
        GameObject newGO = Instantiate(tile, transform.forward*zSpawn, transform.rotation);
        activeTiles.Add(newGO);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    
}
