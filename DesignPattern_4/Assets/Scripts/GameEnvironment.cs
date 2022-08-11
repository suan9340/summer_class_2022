using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameEnvironment : MonoBehaviour
{
    public List<GameObject> checkPointList = new List<GameObject>();

    private static GameEnvironment _instance;
    public static GameEnvironment Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameEnvironment();
                _instance.checkPointList.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                _instance.checkPointList = _instance.checkPointList.OrderBy(waypoint => waypoint.name).ToList();
            }
            return _instance;
        }

    }
}
