using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : Menu<SettingMenu>
{
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
