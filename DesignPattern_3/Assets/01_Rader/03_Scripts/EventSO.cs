using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "SO/EventSO")]
public class EventSO : ScriptableObject
{
    private List<EventListner> eListenerList = new List<EventListner>();

    public void Register(EventListner _listener)
    {
        eListenerList.Add(_listener);
    }

    public void UnRegister(EventListner _listner)
    {
        eListenerList.Remove(_listner);
    }

    public void Occurred(GameObject _go)
    {
        for (int i = 0; i < eListenerList.Count; i++)
        {
            eListenerList[i].OnEventOccurs(_go);
        }
    }
}
