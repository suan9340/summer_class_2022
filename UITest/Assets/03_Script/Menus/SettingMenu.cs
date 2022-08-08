using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : Menu
{
    private static SettingMenu _instance;
    public static SettingMenu Instance { get { return _instance; } }

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

    public void OnClickBGM()
    {
        Debug.Log("BGM 설정\n");
    }

    public void OnClickSFX()
    {
        Debug.Log("SFX 설정\n");
    }

    public void OnClickReview()
    {
        Debug.Log("평가하기\n");
    }

    public override void OnClickBack()
    {
        base.OnClickBack();
    }
}
