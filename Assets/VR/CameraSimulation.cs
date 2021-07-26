using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSimulation : MonoBehaviour
{

    float mouseX;
    float mouseY;
    float mouseZ;
    Quaternion HeadRotation;
    //public Transform CamTr;

    void Update()
    {
#if UNITY_EDITOR

        Debug.Log("Unity Editor");


        bool rolled = false;
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseX += Input.GetAxis("Mouse X") * 5;
            if (mouseX <= -180)
            {
                mouseX += 360;
            }
            else if (mouseX > 180)
            {
                mouseX -= 360;
            }

            mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
            mouseY = Mathf.Clamp(mouseY, -85, 85);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            rolled = true;
            mouseZ += Input.GetAxis("Mouse X") * 5;
            mouseZ = Mathf.Clamp(mouseZ, -85, 85);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (!rolled)
        {
            mouseZ = Mathf.Lerp(mouseZ, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }

        HeadRotation = Quaternion.Euler(mouseY, mouseX, mouseZ);
        this.transform.localRotation = HeadRotation;
#endif
    }

}
