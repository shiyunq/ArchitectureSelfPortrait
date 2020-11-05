using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public bool lockCursor = true;
    public Text t;
    bool wait = false;
    string theTag;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
            //Cursor.visible = !Cursor.visible;
        }

        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !lockCursor;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    UnityEngine.Debug.Log(hit.transform.gameObject.tag);
                    Analyze(hit.transform.gameObject.tag);
                }
            }
        }

        if (wait)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Go();
            }
        }
    }

    void Analyze(string tag)
    {
        if (tag.Equals("tv"))
        {
            wait = true;
            theTag = "ColorInitialization";
            double X, Y;
            if (Clock.height >= 1)
            {
                X = Math.Round(4.74 / 6 * Clock.height, 2);
                Y = Math.Round(2.61 / 6 * Clock.height, 2);
                t.text = "TV: " + X + "' x " + Y + "'";

                if (Clock.colorSensitivity < 1)
                    t.text += "\nLET'S PLAY A VIDEO GAME ON THE TV!\nPRESS ENTER TO CONTINUE.";
            }
            else
            {
                if (Clock.colorSensitivity < 1)
                    t.text = "LET'S PLAY A VIDEO GAME ON THE TV!\nPRESS ENTER TO CONTINUE.";
                else
                    t.text = "TV";
            }
        }

        if (tag.Equals("bookcase") || tag.Equals("books") || tag.Equals("toy"))
        {
            wait = true;
            theTag = "HeightStart";
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(6.07 / 6 * Clock.height, 2);
                Y = Math.Round(1.28 / 6 * Clock.height, 2);
                Z = X;
                t.text = "BOOKSHELF: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "YOU SAW SOMETHING NEAR THE BOOKSHELF...\nPRESS ENTER TO CONTINUE.";
            }
        }

        if (tag.Equals("closet"))
        {
            wait = true;
            theTag = "ClosetStart";
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(7.94 / 6 * Clock.height, 2);
                Y = Math.Round(2.00 / 6 * Clock.height, 2);
                Z = Math.Round(3.13 / 6 * Clock.height, 2);
                t.text = "SMALL WARDROBE: " + X + "' x " + Y + "' x " + Z + "'";
                if (!Clock.closetPlayed)
                    t.text += "\nYOU WALKED TOWARD THE SMALL WARDROBE...\nPRESS ENTER TO CONTINUE.";
            }
            else
            {
                if (!Clock.colorAssigned)
                    t.text = "YOU WALKED TOWARD THE SMALL WARDROBE...\nPRESS ENTER TO CONTINUE.";
                else
                    t.text = "SMALL WARDROBE";
            }
        }

        if (tag.Equals("teatable"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(3.71 / 6 * Clock.height, 2);
                Y = Math.Round(1.97 / 6 * Clock.height, 2);
                Z = Math.Round(1.00 / 6 * Clock.height, 2);
                t.text = "TEATABLE: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "TEATABLE";
            }
        }

        if (tag.Equals("couch"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(6.37 / 6 * Clock.height, 2);
                Y = Math.Round(2.74 / 6 * Clock.height, 2);
                Z = Math.Round(2.92 / 6 * Clock.height, 2);
                t.text = "COUCH: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "COUCH";
            }
        }

        if (tag.Equals("tvstand"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(5.94 / 6 * Clock.height, 2);
                Y = Math.Round(2.00 / 6 * Clock.height, 2);
                Z = Math.Round(1.22 / 6 * Clock.height, 2);
                t.text = "TV STAND: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "TV STAND";
            }
        }

        if (tag.Equals("door"))
        {
            wait = false;
            double X, Y;
            if (Clock.height >= 1)
            {
                X = Math.Round(3.00 / 6 * Clock.height, 2);
                Y = Math.Round(7.00 / 6 * Clock.height, 2);
                t.text = "DOOR: " + X + "' x " + Y + "'";
            }
            else
            {
                t.text = "DOOR";
            }
        }

        if (tag.Equals("fridge"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(3.00 / 6 * Clock.height, 2);
                Y = Math.Round(3.00 / 6 * Clock.height, 2);
                Z = Math.Round(6.00 / 6 * Clock.height, 2);
                t.text = "FRIDGE: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "FRIDGE";
            }
        }

        if (tag.Equals("wall"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(15.00 / 6 * Clock.height, 2);
                Y = Math.Round(32.00 / 6 * Clock.height, 2);
                Z = Math.Round(20.00 / 6 * Clock.height, 2);
                t.text = "LOFT DIMENSIONS: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "WALL";
            }
        }

        if (tag.Equals("floor"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(15.00 / 6 * Clock.height, 2);
                Y = Math.Round(32.00 / 6 * Clock.height, 2);
                Z = Math.Round(20.00 / 6 * Clock.height, 2);
                t.text = "LOFT DIMENSIONS: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "FLOOR";
            }
        }

        if (tag.Equals("toilet"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(1.53 / 6 * Clock.height, 2);
                Y = Math.Round(2.13 / 6 * Clock.height, 2);
                Z = Math.Round(2.58 / 6 * Clock.height, 2);
                t.text = "TOILET: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "TOILET";
            }
        }

        if (tag.Equals("chair"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(1.44 / 6 * Clock.height, 2);
                Y = Math.Round(1.63 / 6 * Clock.height, 2);
                Z = Math.Round(2.44 / 6 * Clock.height, 2);
                t.text = "CHAIR: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "CHAIR";
            }
        }

        if (tag.Equals("desk"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(6.83 / 6 * Clock.height, 2);
                Y = Math.Round(2.54 / 6 * Clock.height, 2);
                Z = Math.Round(2.65 / 6 * Clock.height, 2);
                t.text = "DESK: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "DESK";
            }
        }

        if (tag.Equals("kitchen"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(2.67 / 6 * Clock.height, 2);
                Y = Math.Round(6.33 / 6 * Clock.height, 2);
                Z = Math.Round(3.17 / 6 * Clock.height, 2);
                t.text = "CABINET: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "CABINET";
            }
        }

        if (tag.Equals("railings"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(3.00 / 6 * Clock.height, 2);
                Y = Math.Round(1.00 / 6 * Clock.height, 2);
                Z = Math.Round(0.50 / 6 * Clock.height, 2);
                t.text = "STAIR: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "STAIR";
            }
        }

        if (tag.Equals("bed"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(7.02 / 6 * Clock.height, 2);
                Y = Math.Round(5.70 / 6 * Clock.height, 2);
                Z = Math.Round(2.16 / 6 * Clock.height, 2);
                t.text = "BED: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "BED";
            }
        }

        if (tag.Equals("bedside"))
        {
            wait = false;
            double X, Y, Z;
            if (Clock.height >= 1)
            {
                X = Math.Round(1.64 / 6 * Clock.height, 2);
                Y = Math.Round(1.31 / 6 * Clock.height, 2);
                Z = Math.Round(2.30 / 6 * Clock.height, 2);
                t.text = "BEDSIDE TABLE: " + X + "' x " + Y + "' x " + Z + "'";
            }
            else
            {
                t.text = "BEDSIDE TABLE";
            }
        }
    }

    void Go()
    {
        Clock.X = playerBody.transform.position.x;
        Clock.Z = playerBody.transform.position.z;
        SceneManager.LoadScene(theTag);
    }
}
