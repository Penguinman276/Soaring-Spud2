using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Vector3Int ChunkSize = new Vector3Int(16, 256, 16);
    public Vector2 NoiseScale = Vector2.one;
    public Vector2 NoiseOffset = Vector2.zero;
    private int[,,] TempData;
    // Start is called before the first frame update
    void Start()
    {
        TempData = new int[ChunkSize.x, ChunkSize.y, ChunkSize.z];

        for (int x = 0; x < ChunkSize.x; x++)
        {
            for(int z = 0; z < ChunkSize.z; z++)
            {
                float PerlinCoordX = NoiseOffset.x + x / (float)ChunkSize.x * NoiseScale.x;
                float PerlinCoordY = NoiseOffset.y + z / (float)ChunkSize.z * NoiseScale.y;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
