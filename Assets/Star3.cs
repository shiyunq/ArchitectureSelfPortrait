using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star3 : MonoBehaviour
{
    public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        if (Clock.aH1 > 0)
            GetComponent<RawImage>().texture = texture;
    }
}
