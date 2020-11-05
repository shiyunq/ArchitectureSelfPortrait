using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosetStart2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Continue()
    {
        SceneManager.LoadScene("ColorPreference");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Help()
    {
        SceneManager.LoadScene("PreferenceHelp");
    }
}
