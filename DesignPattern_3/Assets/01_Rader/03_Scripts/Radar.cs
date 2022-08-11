using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarObject
{
    public Image icon { get; set; }
    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour
{
    public Transform playerPosTrn = null;
    public static List<RadarObject> radObList = new List<RadarObject>();
    private const float MAP_SCALE = 2.0f;

    private void Update()
    {
        DrawRadarDots();
    }

    private void DrawRadarDots()
    {
        foreach (RadarObject radobj in radObList)
        {
            Vector3 _radarPos = (radobj.owner.transform.position - playerPosTrn.position);

            var _distToObject = Vector3.Distance(playerPosTrn.position, radobj.owner.transform.position) * MAP_SCALE;
            var _deltaY = Mathf.Atan2(_radarPos.x, _radarPos.z) * Mathf.Rad2Deg - 270 - playerPosTrn.eulerAngles.y;

            _radarPos.x = _distToObject * Mathf.Cos(_deltaY * Mathf.Deg2Rad) * -1;
            _radarPos.z = _distToObject * Mathf.Sin(_deltaY * Mathf.Deg2Rad);

            RectTransform _rt = this.GetComponent<RectTransform>();

            radobj.icon.transform.SetParent(this.transform);

            radobj.icon.transform.position = new Vector3(_radarPos.x + _rt.pivot.x, _radarPos.z + _rt.pivot.y, 0) + this.transform.position;
        }
    }

    public void ItemDropped(GameObject _go)
    {
        Debug.Log("아이템이 드랍됬어");
        ResisterRadarObj(_go, _go.GetComponent<Item>().icon);
    }

    private static void ResisterRadarObj(GameObject _go, Image _icon)
    {
        Image _image = Instantiate(_icon);
        radObList.Add(new RadarObject() { owner = _go, icon = _image });
    }

    private static void RemoveRadarObj(GameObject _obj)
    {
        List<RadarObject> _newList = new List<RadarObject>();
        for(int i = 0;i<radObList.Count;i++)
        {
            if(radObList[i].owner == _obj)
            {
                Destroy(radObList[i].icon);
                continue;
            }
            else
            {
                _newList.Add(radObList[i]);
            }
        }

        radObList.RemoveRange(0,radObList.Count);
        radObList.AddRange(_newList);
    }

    public void ItemPickUp(GameObject _go)
    {
        RemoveRadarObj(_go);
    }
}
