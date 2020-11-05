using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public GameObject i1;
    public GameObject i2;

    // Start is called before the first frame update
    public void update()
    {
        int foot;
        double inch;
        Int32.TryParse(i1.GetComponent<Text>().text, out foot);
        Double.TryParse(i2.GetComponent<Text>().text, out inch);

        Clock.height = Math.Round(foot + inch / 12, 4);
        UnityEngine.Debug.Log(Clock.height);
        SceneManager.LoadScene("HeightEnd");
    }
}
