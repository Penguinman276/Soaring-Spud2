using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;
    public GameObject player;
    public Vector3 startPosition;

    Vector3[] vertices;
    int[] triangles;
    public float meshScale = 1f;
    public int xSize = 20;
    public int zSize = 20;
    public Vector2 chunkCoord;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

    }
    // video link https://www.youtube.com/watch?v=WP-Bm65Q-1Y

    // Update is called once per frame
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float xCoord = (x + chunkCoord.x * xSize) * 0.1f;
                float zCoord = (z + chunkCoord.y * zSize) * 0.1f;

                float y = Mathf.PerlinNoise(x * 0.1f, z * 0.1f) * 3f;
                vertices[i] = new Vector3(x * meshScale, y * meshScale, z * meshScale);
                i++;
            }
        }
        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;


            }
            vert++;
        }





    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

    }


}