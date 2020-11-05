using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosetStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void Continue()
    {
        SceneManager.LoadScene("ClosetStart2");
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
