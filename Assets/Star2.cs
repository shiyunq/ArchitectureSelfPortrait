using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star2 : MonoBehaviour
{
    public Texture2D texture;

    // Start is called before the first frame update
    void Start()
    {
        if (Clock.height >= 1)
            GetComponent<RawImage>().texture = texture;
    }
}
