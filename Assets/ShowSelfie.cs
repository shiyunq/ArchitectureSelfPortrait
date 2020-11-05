using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelfie : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        GetComponent<RawImage>().texture = Clock.selfie;
    }
}
