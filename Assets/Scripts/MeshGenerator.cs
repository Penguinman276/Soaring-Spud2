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
    public int seed = 89416215;

    private MeshCollider meshCollider;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Get or add MeshCollider
        meshCollider = GetComponent<MeshCollider>();
        if (meshCollider == null)
        {
            meshCollider = gameObject.AddComponent<MeshCollider>();
        }

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z < zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float xCoord = (x + chunkCoord.x * xSize + seed) * 0.3f;
                float zCoord = (z + chunkCoord.y * zSize + seed) * 0.3f;

                float y = Mathf.PerlinNoise(xCoord, zCoord) * 3f;

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

        if (meshCollider == null)
        {
            meshCollider = GetComponent<MeshCollider>();
        }

        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = mesh;

        float maxHeight = 0f;

        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].y > maxHeight)
            {
                maxHeight = vertices[i].y;
            }
        }

        void UpdateMesh()
        {
            mesh.Clear();

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();

            if (meshCollider == null)
            {
                meshCollider = GetComponent<MeshCollider>();
            }

            meshCollider.sharedMesh = null;
            meshCollider.sharedMesh = mesh;
        }

    }

}