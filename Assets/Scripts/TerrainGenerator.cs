using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Vector3Int ChunkSize = new Vector3Int(16, 256, 16);
    public Vector2 NoiseScale = Vector2.one;
    public Vector2 NoiseOffset = Vector2.zero;
    [Space]
    private int[,,] TempData;
    public int HeightOffset = 60;
    public float HeightIntensity = 5f;
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
                int HeightGen = Mathf.RoundToInt(Mathf.PerlinNoise(PerlinCoordX, PerlinCoordY) * HeightIntensity + HeightOffset);

                for(int y = HeightGen; y >= 0; y--)
                {

                }
            }
        }
    }
    //video link https://www.youtube.com/watch?v=esV1-2hB17E&list=PLEvnA6UOOVbkOTaFPe4P0RA3W1mINbWCf
    // Update is called once per frame
    void Update()
    {
        
    }
}
