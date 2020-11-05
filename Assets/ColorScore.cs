using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class ColorScore : MonoBehaviour
{
    public Text textBox0;
    public Text textBox1;

    // Start is called before the first frame update
    void Start()
    {
        string theText;
        if (Clock.count[0] < 5) theText = "COOL!";
        else if (Clock.count[0] < 9) theText = "AWESOME!";
        else theText = "BRAVO!";
        textBox0.text = theText;
        textBox1.text = "Your Score in Round 1 is " + Clock.count[0].ToString();
    }

    public void Round2()
    {
        Clock.timeStart = 20;
        SceneManager.LoadScene("ColorLevel11");
    }
}
