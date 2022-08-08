using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : Menu<MainMenu>
{
    public void OnClickPlay()
    {
        Debug.Log("���� ����\n");
    }

    public void OnClickSetting()
    {
        SettingMenu.Open();
    }

    public void OnClickCredit()
    {
        CreditMenu.Open();
    }

    public override void OnClickBack()
    {
        base.OnClickBack();
    }
}
