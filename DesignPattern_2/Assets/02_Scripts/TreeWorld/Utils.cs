using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public static class Utils
{
    private static System.Random random = new System.Random();
    public static string SettingRandomName(int _maxLenght)
    {
        const string _chars = "ABCDEFGHIJKLMNOPQRSTUVXTZ0123456789";
        return new string(Enumerable.Repeat(_chars, _maxLenght).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static T SettingRandomThreat<T>()
    {
        Array _value = Enum.GetValues(typeof(T));
        return (T)_value.GetValue(random.Next(_value.Length));
    }
}
