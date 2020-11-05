using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Configuration;

public class HeightMeasurer : MonoBehaviour
{
    double dis;
    double v0;
    const double T = 0.02;
    const double CO = 3.28084;
    public Text text0;
    public Text text1;
    public Text text2;
    public Texture2D texture;
    public Sprite Image1;
    public GameObject button;

    void Start()
    {
        enabled = false;
        //button.text = "Start";
    }

    void FixedUpdate()
    {

        double x = Input.acceleration.x;
        double y = Input.acceleration.y;
        double z = Input.acceleration.z;

        double a = Math.Round(Math.Sqrt(x * x + y * y + z * z) * 9.8 - 9.8, 2);
        double delta = v0 * T + 0.5 * a * T * T;

        if (Math.Abs(a) > 0.2)
        {
            v0 += a * T;
            dis += Math.Round(delta * CO, 4);
        }
        //textBox.text = dis.ToString() + "'";
    }

    public void record()
    {
        if (enabled)
        {
            enabled = false;
            //button.text = "Start";
            UnityEngine.Debug.Log(dis);
            Clock.height = dis;
            if (dis < 4)
                SceneManager.LoadScene("HeightInput");
            else
                SceneManager.LoadScene("HeightEnd");
        }
        else
        {
            dis = 0.0;
            v0 = 0.0;
            enabled = true;
            //button.text = "Record";
            //button.GetComponent<button>().
            text1.text = "STAND UP AND RAISE YOUR PHONE SLIGHTLY ABOVE YOUR HEAD.";
            text2.text = "TAP THE BUTTON TO PUT THE BOOK BACK.";
            text0.text = "STEP 3";
            GetComponent<RawImage>().texture = texture;
            button.GetComponent<Image>().sprite = Image1;
        }
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main");
    }

    public void Help()
    {
        SceneManager.LoadScene("HeightHelp");
    }
}
