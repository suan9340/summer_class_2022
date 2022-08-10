using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantData", menuName = "SO/PlantData")]

public class paintDataSO : ScriptableObject
{
    public enum eThreat : int
    {
        None = 0,
        Low,
        Moderate,
        High
    }

    [SerializeField] private string plantName;
    [SerializeField] private eThreat ePlantThreat;
    [SerializeField] private Texture icon;

    public string Name { get { return plantName; } }
    public eThreat Threat { get { return ePlantThreat; } }
    public Texture Icon { get { return icon; } }

    public void SetRandomName()
    {
        var _nameLenght = Random.Range(4, 10);
        plantName = Utils.SettingRandomName(_nameLenght);
    }

    public void SetRandomThreat()
    {
        ePlantThreat = Utils.SettingRandomThreat<eThreat>();
    }
}
