using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class InfiniteTerrainGenerator : MonoBehaviour
{
   // [SerializeField] private Transform Player;
   //<summary>
   /// [SerializeField] private int RenderDistance;
   /// </summary>
   // private WorldGenerator GeneratorInstance;
   // private List<Vector2Int> CoordsToRemove;
    // Start is called before the first frame update
    void Start()
    {
       // GeneratorInstance = GetComponent<WorldGenerator>();
       // CoordsToRemove = new List<Vector2Int>();
    }

    // Update is called once per frame
    void Update()
    {
        //int plrChunkX = (int)Player.position.x / WorldGenerator.ChunkSize.x;
       // //int plrChunkY = (int)Player.position.y / WorldGenerator.ChunkSize.z;
       // CoordsToRemove.Clear();
//
       //// foreach(KeyValuePair<Vector2Int, GameObject> activeChunk in WorldGenerator.ActiveChunks)
      //  {
       //     CoordsToRemove.Add(activeChunk.Key);
       // }

      //  for(int x = plrChunkX - RenderDistance; x <= plrChunkX + RenderDistance; x++)
      //  {
       ///     for(int y = plrChunkY - RenderDistance; y <= PlrChunkY + RenderDistance; y++)
       //     {
       //         Vector2Int chunkCoord = new Vector2Int(x, y);
       //         if (!WorldGenerator.ActiveChunks.ContainsKey(chunkCoord))
              //  {
        //            GeneratorInstance.CreateChunk(chunkCoord);
             //   }
         //   }
      ///  }
    }
}
