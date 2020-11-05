using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeightResult : MonoBehaviour
{
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "ALSO BEEN ADJUSTED ACCORDING TO YOUR HEIGHT (AROUND " + Clock.height + "').";
    }

    public void GoBack()
    {
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

    public void Help()
    {
        SceneManager.LoadScene("HeightHelp");
    }

    public void Restart()
    {
        SceneManager.LoadScene("HeightStart");
    }
}
