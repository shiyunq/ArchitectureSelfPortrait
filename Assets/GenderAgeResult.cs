using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenderAgeResult : MonoBehaviour
{
    public Text text1;
    public Text text2;

    private void Start()
    {
        //if (Clock.gender)
        //    text1.text = "Female";
        //else
        //    text1.text = "Male";

        //text2.text = Clock.age.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("CameraSensor");
    }

    public void Continue()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }
}
