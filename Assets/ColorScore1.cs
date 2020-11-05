using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorScore1 : MonoBehaviour
{
    public Text textBox0;
    public Text textBox1;

    // Start is called before the first frame update
    void Start()
    {
        string theText;
        if (Clock.count[1] < 5) theText = "COOL!";
        else if (Clock.count[1] < 9) theText = "AWESOME!";
        else theText = "BRAVO!";
        textBox0.text = theText;
        textBox1.text = "Your Score in Round 2 is " + Clock.count[1].ToString();
    }

    public void Round3()
    {

        Clock.timeStart = 20;
        SceneManager.LoadScene("ColorLevel21");

    }
}
