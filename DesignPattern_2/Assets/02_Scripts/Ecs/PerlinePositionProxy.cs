using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class PerlinePositionProxy : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity _entity, EntityManager _entityManager, GameObjectConversionSystem _conversionSystem)
    {
        var _data = new PerlinePosition { };
        _entityManager.AddComponentData(_entity, _data);
    }
}
