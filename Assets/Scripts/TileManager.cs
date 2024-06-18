using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 3;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                SpawnInitTile(0, new Vector3(0f, 0f, 0f));

            }
            else
            {
                SpawnInitTile(Random.Range(0, tilePrefabs.Length), new Vector3(0f, 0f, i * 30.0f));
            }
        }
    }

    public void SpawnTile(int tileindex)
    {
        GameObject go = Instantiate(tilePrefabs[tileindex], new Vector3( 0f, 0f, 90.0f) , transform.rotation);
        activeTiles.Add(go);
    }
    public void SpawnInitTile(int tileindex, Vector3 position)
    {
        GameObject go = Instantiate(tilePrefabs[tileindex], position, transform.rotation);
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }
    
    private void OnEnable()
    {
        // Subscribe to the collision event
        EventManager.OnCollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        // Unsubscribe from the collision event to avoid memory leaks
        EventManager.OnCollisionDetected -= OnCollisionDetected;
    }
    private void OnCollisionDetected(GameObject collider)
    {
        SpawnTile(Random.Range(0, tilePrefabs.Length));
        DeleteTile();
    }


}


