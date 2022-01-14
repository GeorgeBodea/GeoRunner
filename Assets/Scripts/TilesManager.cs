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
            SpawnTile(easyTilesPrefabs[Random.Range(0,easyTilesPrefabs.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
