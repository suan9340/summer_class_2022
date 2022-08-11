using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    private Text text = null;

    private StringBuilder sb;

    private void Awake()
    {
        sb = new StringBuilder();
    }

    private void Start()
    {
        text = GetComponent<Text>();
        text.enabled = false;
    }
    
    public void SetMessage(GameObject _go)
    {
        sb.Remove(0, sb.Length);
        sb.AppendFormat($"{_go.name} æ∆¿Ã≈€ »πµÊ!!");
        text.text = sb.ToString();

        text.enabled = true;

        Invoke(nameof(Turnoff), 3f);
    }

    private void Turnoff()
    {
        text.enabled = false;
    }
}
