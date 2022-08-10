using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject carObj = null;
    public GameObject mainCam = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 _pos = new Vector3(10f, 10f, 10f);
            GameObject _obj = Instantiate(carObj, _pos, Quaternion.identity);
            mainCam.GetComponent<SmoothFollow>().target = _obj.transform;
        }
    }
}
