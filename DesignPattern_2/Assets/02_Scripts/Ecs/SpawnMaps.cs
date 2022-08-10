using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaps : MonoBehaviour
{
    public GameObject cubePrefab = null;

    public int width;
    public int depth;

    private void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                GameObject _obj = Instantiate(cubePrefab);
                Vector3 _pos = new Vector3(x, Mathf.PerlinNoise(x * 0.21f, z * 0.21f), z);
                _obj.transform.position = _pos;
            }
        }
    }
}
