using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class CameraManager : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    // Replace <Subscription Key> with your valid subscription key.
    const string subscriptionKey = "5b4e30ae85f84521ad508eac0c87b97f";

    // replace <myresourcename> with the string found in your endpoint URL
    const string uriBase =
        "https://csqface.cognitiveservices.azure.com/face/v1.0/detect";

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            useCamera();
        }
        else
        {
            UnityEngine.Debug.Log("webcam not found");
        }
    }

    private void useCamera()
    {
        //Clock.timeStart = 3;
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            UnityEngine.Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
        }

        if (backCam == null)
        {
            UnityEngine.Debug.Log("Unable to find back camera");
            return;
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

        //float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        //background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        //int orient = -backCam.videoRotationAngle;
       // background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

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

    IEnumerator TakePhoto()
    {
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(backCam.width, backCam.height);
        photo.SetPixels(backCam.GetPixels());
        photo.Apply();
        Clock.selfie = photo;

        byte[] bytes = photo.EncodeToJPG();

        //File.WriteAllBytes(Application.dataPath + "/Resources/selfie.jpg", bytes);
        backCam.Stop();
        MakeAnalysisRequest(bytes);
    }

    // Gets the analysis of the specified image by using the Face REST API.
    static async void MakeAnalysisRequest(byte[] byteData)
    {
        HttpClient client = new HttpClient();

        // Request headers.
        client.DefaultRequestHeaders.Add(
            "Ocp-Apim-Subscription-Key", subscriptionKey);

        // Request parameters. A third optional parameter is "details".
        string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
            "&returnFaceAttributes=age,gender";

        // Assemble the URI for the REST API Call.
        string uri = uriBase + "?" + requestParameters;

        HttpResponseMessage response;

        using (ByteArrayContent content = new ByteArrayContent(byteData))
        {
            // This example uses content type "application/octet-stream".
            // The other content types you can use are "application/json"
            // and "multipart/form-data".
            content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            // Execute the REST API call.
            response = await client.PostAsync(uri, content);

            // Get the JSON response.
            string contentString = await response.Content.ReadAsStringAsync();

            // Display the JSON response.
            UnityEngine.Debug.Log("\nResponse:\n");

            string result = JsonPrettyPrint(contentString);
            UnityEngine.Debug.Log(result);
            int i = result.IndexOf("gender");
            if ((i + 10) < result.Length)
            {
                if (result[i + 10] == 'm')
                {
                    Clock.gender = false;
                    UnityEngine.Debug.Log("male");
                }
                if (result[i + 10] == 'f')
                {
                    Clock.gender = true;
                    UnityEngine.Debug.Log("female");
                }
            }

            int j = result.IndexOf("age");
            if ((j + 6) < result.Length)
            {
                Int32.TryParse(result.Substring(j + 6, 2), out Clock.age);
                UnityEngine.Debug.Log(result.Substring(j + 6, 2));
            }
            SceneManager.LoadScene("GenderAgeResult");
        }
    }

    // Formats the given JSON string by adding line breaks and indents.
    static string JsonPrettyPrint(string json)
    {
        if (string.IsNullOrEmpty(json))
            return string.Empty;

        json = json.Replace(Environment.NewLine, "").Replace("\t", "");

        StringBuilder sb = new StringBuilder();
        bool quote = false;
        bool ignore = false;
        int offset = 0;
        int indentLength = 3;

        foreach (char ch in json)
        {
            switch (ch)
            {
                case '"':
                    if (!ignore) quote = !quote;
                    break;
                case '\'':
                    if (quote) ignore = !ignore;
                    break;
            }

            if (quote)
                sb.Append(ch);
            else
            {
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        sb.Append(Environment.NewLine);
                        sb.Append(new string(' ', ++offset * indentLength));
                        break;
                    case '}':
                    case ']':
                        sb.Append(Environment.NewLine);
                        sb.Append(new string(' ', --offset * indentLength));
                        sb.Append(ch);
                        break;
                    case ',':
                        sb.Append(ch);
                        sb.Append(Environment.NewLine);
                        sb.Append(new string(' ', offset * indentLength));
                        break;
                    case ':':
                        sb.Append(ch);
                        sb.Append(' ');
                        break;
                    default:
                        if (ch != ' ') sb.Append(ch);
                        break;
                }
            }
        }

        return sb.ToString().Trim();
    }
}
