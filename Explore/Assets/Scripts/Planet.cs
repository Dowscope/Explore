using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2, 256)]
    public int resolution = 10;

    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    TerrianFace[] terrianFaces;

    private void OnValidate()
    {
        initialize();
        GenerateMesh();
    }
    void initialize()
    {
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }

        terrianFaces = new TerrianFace[6];

        Vector3[] direction = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObject = new GameObject("Mesh");
                meshObject.transform.parent = transform;

                meshObject.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObject.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();

            }

            terrianFaces[i] = new TerrianFace(meshFilters[i].sharedMesh, resolution, direction[i]);
        }
    }
    void GenerateMesh()
    {
        foreach (TerrianFace face in terrianFaces)
        {
            face.constructMesh();
        }
    }
}
