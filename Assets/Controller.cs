using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Controller : MonoBehaviour
{
    private bool increase = false;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = Clock.name;
        if (Clock.age > 50 || Clock.colorSensitivity < 7) increase = true;

        UpdateColor("tvstand");
        UpdateColor("teatable");
        UpdateColor("couch");
        UpdateColor("tv");
        UpdateColor("wall");
        UpdateColor("floor");
        UpdateColor("door");
        UpdateColor("railings");
        UpdateColor("fridge");
        UpdateColor("toilet");
        UpdateColor("chair");
        UpdateColor("desk");
        UpdateColor("kitchen");
        UpdateColor("bookcase");
        UpdateColor("toy");
        UpdateColor("bed");
        UpdateColor("bedside");
        UpdateColor("closet");
        UpdateColor("books");

        Clock.initialized = true;
        Clock.colorPlayed = false;
        Clock.closetPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateColor(string tag)
    {
        if (!Clock.initialized || Clock.colorPlayed || Clock.closetPlayed)
        {
            Clock.colors.Clear();
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            float hi = 0.5f;
            float lo = 0.5f;

            if (increase)
            {
                hi = 0.75f;
                lo = 0.25f;
            }

            float s = UnityEngine.Random.Range(0.0f, hi);
            float v = UnityEngine.Random.Range(lo, 1.0f);
            int seed = UnityEngine.Random.Range(0, 4);
            float h;

            foreach (GameObject i in objects)
            {
                var renderer = i.GetComponent<Renderer>();
                switch (seed)
                {
                    case 0:
                        h = Clock.aH1;
                        break;
                    case 1:
                        h = Clock.aH2;
                        break;
                    case 2:
                        h = Clock.aH3;
                        break;
                    default:
                        h = Clock.aH4;
                        break;
                }

                Color c;
                if (tag.Equals("tv") || tag.Equals("books"))
                    c = Color.HSVToRGB(h, UnityEngine.Random.Range(0.0f, hi), UnityEngine.Random.Range(lo, 1.0f));
                else if (tag.Equals("wall") || tag.Equals("toilet"))
                    c = Color.HSVToRGB(h, s, UnityEngine.Random.Range(0.9f, 1.0f));
                else
                    c = Color.HSVToRGB(h, s, v);

                renderer.material.SetColor("_Color", c);
                Clock.colors.Add(i, c);
            }
        }
    }

    public void help()
    {
        SceneManager.LoadScene("MainHelp");
    }
}
