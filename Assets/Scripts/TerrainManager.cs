using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public Transform player;
    public GameObject chunkPrefab;

    public int chunkSize = 20;
    public int viewDistance = 3;

    Dictionary<Vector2, GameObject> chunks = new Dictionary<Vector2, GameObject>();

    void Update()
    {
        UpdateChunks();
    }

    void UpdateChunks()
    {
        Vector2 forward = new Vector2(player.forward.x, player.forward.z).normalized;
        float forwardBias = 2.5f;

        Vector2 playerChunkCoord = new Vector2(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.z / chunkSize)
        );

        HashSet<Vector2> neededChunks = new HashSet<Vector2>();

        for (int z = -viewDistance; z <= viewDistance; z++)
        {
            for (int x = -viewDistance; x <= viewDistance; x++)
            {
                Vector2 offset = new Vector2(x, z);

                // Check if this offset is in front of the player
                float forwardAmount = Vector2.Dot(offset, forward);

                if (forwardAmount > 0)
                {
                    offset += forward * forwardBias;
                }

                Vector2 coord = new Vector2(
                 playerChunkCoord.x + x,
                 playerChunkCoord.y + z
                 );

                neededChunks.Add(coord);

                if (!chunks.ContainsKey(coord))
                {
                    SpawnChunk(coord);
                }
            }
        }


        List<Vector2> chunksToRemove = new List<Vector2>();

        foreach (var kvp in chunks)
        {
            if (!neededChunks.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                chunksToRemove.Add(kvp.Key);
            }
        }

        foreach (var coord in chunksToRemove)
        {
            chunks.Remove(coord);
        }
    }

    void SpawnChunk(Vector2 coord)
    {
        Vector3 position = new Vector3(
      coord.x * chunkSize,
       0,
      coord.y * chunkSize
     );


        GameObject chunk = Instantiate(chunkPrefab, position, Quaternion.identity);

        BoxCollider generator = chunk.GetComponent<BoxCollider>();
        

        chunks.Add(coord, chunk);
    }
}
