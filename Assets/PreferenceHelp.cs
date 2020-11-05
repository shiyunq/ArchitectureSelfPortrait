using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PreferenceHelp : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("ClosetStart");
    }
}
