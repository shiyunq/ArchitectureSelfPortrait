using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("color");

        if (objs.Length > 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
