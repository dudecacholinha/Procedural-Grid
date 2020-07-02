using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderer : MonoBehaviour
{

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int xSize = 20;
    public int zSize = 20;
    //Vector2[] uvs;
    Color[] color;
    public Gradient gradiente;
    float minTerrain;
    float maxTerrain;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();


    }
     void Update()
    {
        UpdateMesh();
    }


    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x*.3f, z*.3f) * 2f;
                if (y <minTerrain)
                {
                    minTerrain = y;
                }
                if (y >maxTerrain)
                {
                    maxTerrain = y;
                }
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        int vert = 0;
        int tris = 0;
        triangles = new int[xSize * zSize * 6];
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
        /*uvs = new Vector2[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }*/
        color = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float heigh = Mathf.InverseLerp(minTerrain,maxTerrain,vertices[i].y);
                color[i] = gradiente.Evaluate(heigh);
                i++;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.colors = color;
        //mesh.uv = uvs;
    }
/*
    private void OnDrawGizmos()
    {
        if (vertices==null)
        {
            return;
        }
        for (int i=0;  i<vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i],.1f);
        }
    }
    */
}
