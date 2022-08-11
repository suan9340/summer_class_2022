using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> {}
public class EventListner : MonoBehaviour
{
    public EventSO gEvent;

    public UnityGameObjectEvent responseObj  = new UnityGameObjectEvent();

    private void OnEnable()
    {
        gEvent.Register(this);
    }

    private void OnDisable()
    {
        gEvent.UnRegister(this);
    }

    public void OnEventOccurs(GameObject _go)
    {
        responseObj.Invoke(_go);
    }
}
