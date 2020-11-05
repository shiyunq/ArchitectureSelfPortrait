using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorScore2 : MonoBehaviour
{
    public Text textBox0;
    public Text textBox1;

    // Start is called before the first frame update
    void Start()
    {
        Clock.colorSensitivity = (Clock.count[0] + Clock.count[1] + Clock.count[2]) / 3;
        string theText;
        if (Clock.count[2] < 5) theText = "COOL!";
        else if (Clock.count[2] < 9) theText = "AWESOME!";
        else theText = "BRAVO!";
        textBox0.text = theText;
        textBox1.text = "Your Score in Round 3 is " + Clock.count[2].ToString();
    }

    public void quit()
    {

        Clock.colorPlayed = true;
        if (Clock.total == 2)
        {
            Clock.total++;
            SceneManager.LoadScene("Congrats");
        }
        else
        {
            SceneManager.LoadScene("Main");
            Clock.total++;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("ColorInitialization");
    }
}
