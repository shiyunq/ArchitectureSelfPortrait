using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clock", menuName = "ScriptableObjects")]
public class Clock : ScriptableObject
{
    public static float X;
    public static float Z;

    public static int total;

    public static string name;

    public static float timeStart;

    public static int[] count = new int[3];
    public static int colorSensitivity;

    public static double height;

    public static int age;
    public static bool gender;
    public static Texture2D selfie;
    public static Texture2D clothes;

    public static bool initialized;
    public static bool colorPlayed;
    public static bool colorAssigned;
    public static bool closetPlayed;
    public static Hashtable colors = new Hashtable();

    public static float aH1;
    public static float aH2;
    public static float aH3;
    public static float aH4;

    public static float aS1;
    public static float aS2;
    public static float aS3;
    public static float aS4;

    public static float aV1;
    public static float aV2;
    public static float aV3;
    public static float aV4;
}
