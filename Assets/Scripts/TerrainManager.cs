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
        Vector2 playerChunkCoord = new Vector2(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.z / chunkSize)
        );

        for (int z = -viewDistance; z <= viewDistance; z++)
        {
            for (int x = -viewDistance; x <= viewDistance; x++)
            {
                Vector2 coord = new Vector2(
                    playerChunkCoord.x + x,
                    playerChunkCoord.y + z
                );

                if (!chunks.ContainsKey(coord))
                {
                    SpawnChunk(coord);
                }
            }
        }
    }

    void SpawnChunk(Vector2 coord)
    {
        Vector3 position = new Vector3(
    coord.x * chunkSize + chunkSize / 2f,
    0,
    coord.y * chunkSize + chunkSize / 2f
);

        GameObject chunk = Instantiate(chunkPrefab, position, Quaternion.identity);

        MeshGenerator generator = chunk.GetComponent<MeshGenerator>();
        generator.chunkCoord = coord;

        chunks.Add(coord, chunk);
    }
}
