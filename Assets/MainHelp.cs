using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHelp : MonoBehaviour
{
    public void BackToStart()
    {
        SceneManager.LoadScene("Main");
    }
}
