using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    private static MainMenu _instance;
    public static MainMenu Instance { get { return _instance; } }

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

    public void OnClickPlay()
    {
        Debug.Log("게임 시작\n");
    }

    public void OnClickSetting()
    {
        if (MenuManager.Instance != null && SettingMenu.Instance != null)
        {
            MenuManager.Instance.OpenMenu(SettingMenu.Instance);
        }
    }

    public void OnClickCredit()
    {
        if (MenuManager.Instance != null && CreditMenu.Instance != null)
        {
            MenuManager.Instance.OpenMenu(CreditMenu.Instance);
        }
    }

    public override void OnClickBack()
    {
        base.OnClickBack();
    }
}
