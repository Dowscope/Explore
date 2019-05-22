using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject terrianChunk;

    Hashtable chunks = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(terrianChunk);
        go.name = "Chunk_" + go.transform.position.x + "_" + go.transform.position.z;
        go.transform.parent = this.transform;
        chunks.Add(go.name, go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
