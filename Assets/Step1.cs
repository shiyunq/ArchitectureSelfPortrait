using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Step1 : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("HeightStart2");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Help()
    {
        SceneManager.LoadScene("HeightHelp");
    }
}
