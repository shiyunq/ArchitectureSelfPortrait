using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Entrance : MonoBehaviour
{
    public GameObject inputfield;

    public void Enter()
    {
        Clock.name = inputfield.GetComponent<Text>().text;
        UnityEngine.Debug.Log(Clock.name);
        SceneManager.LoadScene("SelfieStart");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Initialization");
    }

    public void Help()
    {
        SceneManager.LoadScene("MainHelp");
    }
}
