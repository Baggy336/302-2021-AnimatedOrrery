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

        // Use yaw and pitch to move the camera with Euler
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
