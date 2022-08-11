using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "plantdata", menuName = "SO/Plant Data")]
public class PlantDataSO : ScriptableObject
{
    public enum eThreat : int
    {
        None = 0,
        Low,
        Moderate,
        High
    }

    [SerializeField]
    private string plantName;

    [SerializeField]
    private eThreat plantThreat;

    [SerializeField]
    private Texture icon;

    // 2
    public string Name {get {return plantName;}}
    public eThreat Threat {get {return plantThreat;}}
    public Texture Icon {get {return icon;}}

    public void SetRandomName()
    {
        int nameLength = Random.Range(4, 10);
        plantName = Utils.RandomString(nameLength);
    }

    public void SetRandomThreat()
    {
        plantThreat = Utils.RandomEnum<eThreat>();
    }
}
