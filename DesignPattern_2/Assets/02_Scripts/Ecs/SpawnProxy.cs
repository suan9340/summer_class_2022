using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject cubePrefab = null;

    public int rows;
    public int cols;

    public void DeclareReferencedPrefabs(List<GameObject> gameObject)
    {
        gameObject.Add(cubePrefab);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new Spawner
        {
            prefab = conversionSystem.GetPrimaryEntity(cubePrefab),
            erows = rows,
            ecols = cols
        };
    }
}
