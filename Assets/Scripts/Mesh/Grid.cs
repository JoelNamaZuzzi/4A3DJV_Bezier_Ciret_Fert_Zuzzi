using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int Xsize;
    public int Ysize;

    private Vector3[] vertices;
    private Mesh mesh;
    private void Awake () {
        Generate();
    }

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(Xsize + 1) * (Ysize + 1)];
        for (int i = 0, y = 0; y <= Ysize; y++)
        {
            for (int x = 0; x <= Xsize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
            }
        }

        mesh.vertices = vertices;
        int[] triangles = new int[Xsize * Ysize * 6];
        for (int ti = 0, vi = 0, y = 0; y < Ysize; y++, vi++) {
            for (int x = 0; x < Xsize; x++, ti += 6, vi++) {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + Xsize + 1;
                triangles[ti + 5] = vi + Xsize + 2;
            }
        }

        mesh.triangles = triangles;
    }

    private void OnDrawGizmos () {
        if (vertices == null) {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++) {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

}
