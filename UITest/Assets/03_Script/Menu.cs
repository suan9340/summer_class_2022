using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public abstract class Menu : MonoBehaviour
{
    public virtual void OnClickBack()
    {
        if(MenuManager.Instance !=null)
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}
