using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class ColorPreference : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            useCamera();
        }
        else
        {
            Debug.Log("webcam not found");
        }
    }

    private void useCamera()
    {
        //Clock.timeStart = 3;
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }

        if (backCam == null)
        {
            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i].isFrontFacing)
                    backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        backCam.Play();
        camAvailable = true;
    }

    private void Update()
    {
        if (!camAvailable) return;

        background.texture = backCam;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

        //Clock.timeStart -= Time.deltaTime;
    }

    public void OnClick()
    {
        StartCoroutine(TakePhoto());
        enabled = false;
    }

    public void GoBack()
    {
        backCam.Stop();
        SceneManager.LoadScene("Main");
    }

    public void Help()
    {
        SceneManager.LoadScene("PreferenceHelp");
    }

    IEnumerator TakePhoto()
    {
        yield return new WaitForEndOfFrame();

        UnityEngine.Color[] colors = backCam.GetPixels();
        Texture2D photo = new Texture2D(backCam.width, backCam.height);
        photo.SetPixels(colors);
        photo.Apply();
        Clock.clothes= photo;

        float totalH = 0;
        float totalS = 0;
        float totalV = 0;
        int count = 0;
        int l = colors.Length;

        for (int i = 0; i < l/4; i++) {
            float H, S, V;
            UnityEngine.Color c = colors[i];
            UnityEngine.Color.RGBToHSV(c, out H, out S, out V);
            totalH += H;
            totalS += S;
            totalV += V;
            count++;
        }
        Clock.aH1 = totalH / count;
        Clock.aS1 = totalS/ count;
        Clock.aV1 = totalV/ count;
        totalH = 0;
        totalS = 0;
        totalV = 0;
        count = 0;

        for (int i = l/4; i < l / 2; i++)
        {
            float H, S, V;
            UnityEngine.Color c = colors[i];
            UnityEngine.Color.RGBToHSV(c, out H, out S, out V);
            totalH += H;
            totalS += S;
            totalV += V;
            count++;
        }
        Clock.aH2 = totalH / count;
        Clock.aS2 = totalS/ count;
        Clock.aV2 = totalV/ count;
        totalH = 0;
        totalS = 0;
        totalV = 0;
        count = 0;

        for (int i = l / 2; i < 3 * l / 4; i++)
        {
            float H, S, V;
            UnityEngine.Color c = colors[i];
            UnityEngine.Color.RGBToHSV(c, out H, out S, out V);
            totalH += H;
            totalS += S;
            totalV += V;
            count++;
        }
        Clock.aH3 = totalH / count;
        Clock.aS3= totalS/ count;
        Clock.aV3 = totalV / count;
        totalH = 0;
        totalS = 0;
        totalV = 0;
        count = 0;

        for (int i = 3 * l / 4; i < l; i++)
        {
            float H, S, V;
            UnityEngine.Color c = colors[i];
            UnityEngine.Color.RGBToHSV(c, out H, out S, out V);
            totalH += H;
            totalS += S;
            totalV += V;
            count++;
        }
        Clock.aH4 = totalH / count;
        Clock.aS4= totalS / count;
        Clock.aV4= totalV / count;

        backCam.Stop();
        SceneManager.LoadScene("PreferenceResult");
    }
}

   