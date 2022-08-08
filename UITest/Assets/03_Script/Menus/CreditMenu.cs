using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMenu : Menu
{
    private static CreditMenu _instance;
    public static CreditMenu Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;

        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public override void OnClickBack()
    {
        base.OnClickBack();
    }
}
