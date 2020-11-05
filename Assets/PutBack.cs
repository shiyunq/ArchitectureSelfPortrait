using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutBack : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("HeightStart1");
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
