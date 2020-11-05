using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelfieStart : MonoBehaviour
{
    // Update is called once per frame
    public void Yes()
    {
        SceneManager.LoadScene("CameraSensor");
    }

    //public void Help()
    //{
        //SceneManager.LoadScene("SelfieHelp");
    //}

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }
}
