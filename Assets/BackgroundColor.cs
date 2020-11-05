using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundColor : MonoBehaviour
{
    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;

    // Start is called before the first frame update
    void Start()
    {
        o1.GetComponent<RawImage>().color = Color.HSVToRGB(Clock.aH1, Clock.aS1, Clock.aV1);
        o2.GetComponent<RawImage>().color = Color.HSVToRGB(Clock.aH2, Clock.aS2, Clock.aV2);
        o3.GetComponent<RawImage>().color = Color.HSVToRGB(Clock.aH3, Clock.aS3, Clock.aV3);
        o4.GetComponent<RawImage>().color = Color.HSVToRGB(Clock.aH4, Clock.aS4, Clock.aV4);
    }

    public void Restart()
    {
        SceneManager.LoadScene("ColorPreference");
    }

    public void Continue()
    {
        Clock.closetPlayed = true;
        Clock.colorAssigned = true;
        if (Clock.total == 2)
        {
            Clock.total++;
            SceneManager.LoadScene("Congrats");
        }
        else
        {
            Clock.total++;
            SceneManager.LoadScene("Main");
        }
    }

    public void GoBack()
    {
        Clock.closetPlayed = true;
        Clock.colorAssigned = true;
        if (Clock.total == 2)
        {
            Clock.total++;
            SceneManager.LoadScene("Congrats");
        }
        else
        {
            Clock.total++;
            SceneManager.LoadScene("Main");
        }
    }

    public void Help()
    {
        SceneManager.LoadScene("PreferenceHelp");
    }
}
