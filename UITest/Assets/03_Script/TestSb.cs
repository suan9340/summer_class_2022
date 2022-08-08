using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class TestSb : MonoBehaviour
{
    private void Start()
    {
        StringDemo();
    }

    private void StringDemo()
    {
        string s = "";
        StringBuilder sb = new StringBuilder();
        Debug.Log($"StartTime ; {DateTime.Now.ToLongTimeString()}");

        for (int i = 0; i < 1000000; i++)
        {
            s += "гоюл ";
        }

        Debug.Log($"EndTime ; {DateTime.Now.ToLongTimeString()}");
    }
}
