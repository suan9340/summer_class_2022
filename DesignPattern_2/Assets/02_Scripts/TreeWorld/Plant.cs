using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] private paintDataSO plantInfo = null;

    SetPlantInfo spInfo;
    private GameObject player;

    private void Start()
    {
        plantInfo.SetRandomName();
        plantInfo.SetRandomThreat();

        spInfo = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown()
    {
        Debug.Log($"{plantInfo.Name} Å¬¸¯!");

        spInfo.OpenPlantPanel();
        spInfo.phreatLevel.text = plantInfo.Threat.ToString();
        spInfo.plantIcon.GetComponent<RawImage>().texture = plantInfo.Icon;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && plantInfo.Threat >= paintDataSO.eThreat.Moderate)
        {
            Debug.Log("Á×¾ú´Ù!");
            PlayerController.dead = true;
        }
    }
}
