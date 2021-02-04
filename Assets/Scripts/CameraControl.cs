using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Store the YAW of the camera
    float yaw = 0;
    float targetYaw = 0;
    // Store the tilt of the camera
    float pitch = 0;
    float targetPitch = 0;
    // Store how far the camera is from the target
    float dollyDis = 5;
    float targetDollyDis = 5;
    // Store mouse input and sensitivity
    public float mouseWheelMultiplier = 5;
    public float mouseSensX = 1;
    public float mouseSensY = 1;
    // Declare the camera
    private Camera cam;
    public Transform planet1;
    public Transform planet2;
    public Transform planet3;
    public Transform planet4;
    public Transform planet5;
    public Transform planet6;
    public Transform planet7;
    public Transform planet8;

    public Transform subjectPosition;

    void Start()
    {
        // Get the camera component in the child of UI
        cam = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        // Use right click to move the camera around
        if (Input.GetButton("Fire2"))
        {
            // Change the camera pitch
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            targetPitch += mouseY * mouseSensY;
            targetYaw += mouseX * mouseSensX;
        }

        // Get the mouse scroll input for dollyDis
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        // Use scroll to move by dollydis and sensitivity
        targetDollyDis += scroll * mouseWheelMultiplier;
        // Clamp the value so that you don't go through the planet
        targetDollyDis = Mathf.Clamp(targetDollyDis, 5, 20);

        // Ease into the scroll
        dollyDis = AnimMath.Slide(dollyDis, targetDollyDis, .05f);
        // Move the camera along the vector
        cam.transform.localPosition = new Vector3(0, 0, -dollyDis);

        // Clamp the camera pitch
        targetPitch = Mathf.Clamp(targetPitch, -70, 70);
        // Ease into the pitch
        pitch = AnimMath.Slide(pitch, targetPitch, .05f);
        // Ease into the Yaw
        yaw = AnimMath.Slide(yaw, targetYaw, .05f);
        //targetYaw = Mathf.Clamp(targetYaw, 60, -60);

        // Use yaw and pitch to move the camera with Euler
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Switch the camera's focus on a new subject.
        cam.transform.position = subjectPosition.position + new Vector3(0, dollyDis, -dollyDis);
    }

    public void CameraSwitch(int planetNum)
    {
        switch (planetNum)
        {
            case 0:
                subjectPosition = planet1;               
                break;
            case 1:
                subjectPosition = planet2;                
                break;
            case 2:
                subjectPosition = planet3;
                break;
            case 3:
                subjectPosition = planet4;
                break;
            case 4:
                subjectPosition = planet5;
                break;
            case 5:
                subjectPosition = planet6;
                break;
            case 6:
                subjectPosition = planet7;
                break;
            case 7:
                subjectPosition = planet8;
                break;
        }
    }
}
