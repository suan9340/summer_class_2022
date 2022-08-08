using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : Menu<SettingMenu>
{
    public void OnClickBGM()
    {
        Debug.Log("BGM ����\n");
    }

    public void OnClickSFX()
    {
        Debug.Log("SFX ����\n");
    }

    public void OnClickReview()
    {
        Debug.Log("���ϱ�\n");
    }

    public override void OnClickBack()
    {
        base.OnClickBack();
    }
}
