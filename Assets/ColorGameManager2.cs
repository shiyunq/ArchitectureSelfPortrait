using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColorGameManager2 : MonoBehaviour
{
    public static Text textBox;

    void Start()
    {
        textBox = GameObject.Find("Text").GetComponent<Text>();
        textBox.text = Mathf.Round(Clock.timeStart).ToString();
    }

    void Update()
    {
        Clock.timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(Clock.timeStart).ToString();

        if (Mathf.Round(Clock.timeStart) == 0)
            SceneManager.LoadScene("ColorScoreBoard 3");
    }

    public void UserSelectTrue(string sceneName)
    {
        UnityEngine.Debug.Log("CORRECT!");
        Clock.count[2]++;
        SceneManager.LoadScene(sceneName);
    }

    public void UserSelectFalse()
    {
        UnityEngine.Debug.Log("WRONG!");
    }
}
