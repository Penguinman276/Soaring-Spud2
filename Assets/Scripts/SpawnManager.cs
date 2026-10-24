using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;   // Prefab to spawn
    public Transform player;           // Player reference

    public float spawnDistance = 100f;  // How far in front of player
    public float horizontalRange = 50f; // Left/right variation
    public float verticalRange = 20f;   // Up/down variation

    public float spawnRate = 30f;       // Time between spawns

    private float timer;

    public distancetracker disttrak;

    void Update()
    {
        timer += Time.deltaTime;
       
        if (disttrak.distancefromstart >= 1000)
        {
            if (timer >= spawnRate)
            {
                SpawnObject();
                timer = 0f;
            }
        }
        
    }

    void SpawnObject()
    {
        // Get position in front of player
        Vector3 forwardPosition = player.position + player.forward * spawnDistance;

        // Add random offset
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomY = Random.Range(-verticalRange, verticalRange);

        Vector3 spawnPosition = forwardPosition + new Vector3(randomX, randomY, 0f);

        // Spawn object
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}

