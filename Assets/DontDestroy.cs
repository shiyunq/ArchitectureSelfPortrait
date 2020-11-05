using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    private static bool Exists;

    void Awake()
    {
        if (!Exists) //if GameManagerexcistst is not true --> this action will happen.
        {
            Exists = true;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
