using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorInitializer : MonoBehaviour
{
    public Text textBox1;
    public Text textBox2;

    // Start is called before the first frame update
    void Start()
    {
        textBox1.text = "FIND THE BOX WITH A DIFFERENT SHADE OF COLOR.";
        textBox2.text = "ARE YOU READY?";
    }

    public void Round1()
    {
        Clock.timeStart = 20;
        for (int i = 0; i < 3; i++)
            Clock.count[i] = 0;
        SceneManager.LoadScene("ColorLevel1");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Help()
    {
        SceneManager.LoadScene("ColorHelp");
    }
}
