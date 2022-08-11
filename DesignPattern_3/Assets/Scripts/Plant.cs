using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private PlantDataSO plantInfo;

    // 2
    SetPlantInfo spi;

    private void Start() 
    {
        plantInfo.SetRandomName();
        plantInfo.SetRandomThreat();

        // 2
        spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    // 2
    private void OnMouseDown() 
    {
        spi.OpenPlantPanel();
        spi.planeName.text = plantInfo.Name;
        spi.threatLevel.text = plantInfo.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = plantInfo.Icon;
    }

    // 3
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag.Equals("Player") && plantInfo.Threat >= PlantDataSO.eThreat.Moderate)
        {
            PlayerController.dead = true;
        }
    }
}
