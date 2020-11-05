using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreferenceResult : MonoBehaviour
{
    void Start()
    {
        GetComponent<RawImage>().texture = Clock.clothes;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Continue()
    {
        SceneManager.LoadScene("PreferenceResult2");
    }

    public void Restart()
    {
        SceneManager.LoadScene("ColorPreference");
    }

    public void Help()
    {
        SceneManager.LoadScene("PreferenceHelp");
    }
}
