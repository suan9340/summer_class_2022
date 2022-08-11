using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject eggPrefab = null;
    public GameObject medPrefab = null;

    public Terrain terrain = null;
    private TerrainData terrainData = null;

    public enum eItemPrefabs
    {
        Egg,
        Medic,
    }

    private Dictionary<eItemPrefabs, GameObject> itemPrefabDic;

    private void Awake()
    {
        itemPrefabDic = new Dictionary<eItemPrefabs, GameObject>();
        itemPrefabDic.Add(eItemPrefabs.Egg, eggPrefab);
        itemPrefabDic.Add(eItemPrefabs.Medic, eggPrefab);
    }

    private void Start()
    {
        terrainData = terrain.terrainData;

        InvokeRepeating(nameof(CreateEgg), 1, 1);
    }

    private void CreateEgg()
    {
        SelectItemPrefab(eItemPrefabs.Egg);

    }
    private void SelectItemPrefab(eItemPrefabs _eItem)
    {
        var x = (int)Random.Range(0, terrainData.size.x);
        var z = (int)Random.Range(0, terrainData.size.z);

        Vector3 _pos = new Vector3(x, 0, z);
        _pos.y = terrain.SampleHeight(_pos) + 10f;

        GameObject _itmeObj = Instantiate(itemPrefabDic[_eItem], _pos, Quaternion.identity);
        _itmeObj.transform.SetParent(this.transform);
    }

  
}
