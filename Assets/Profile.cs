using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Texture2D t = Clock.selfie;
        int x = (t.width - t.height) / 2;
        Color[] c = Clock.selfie.GetPixels(x, 0, t.height, t.height);
        Texture2D m2Texture = new Texture2D(t.height, t.height);
        m2Texture.SetPixels(c);
        m2Texture.Apply();
        GetComponent<RawImage>().texture = m2Texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
