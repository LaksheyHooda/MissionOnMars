using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    //Sets Sensitivity for player. Changable through unity.
    [SerializeField] float XSensitivity = 50;
    [SerializeField] float YSensitivity = 50;
    [SerializeField] Transform cameraTransform;


    void Start()
    {
        //Makes the mouse invisable and stay at the center of the screen
        //Press esc to leave locked mode (fyi)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePlayerRotation();
        ChangeCameraRotation();
    }

    /// <summary>
    /// Handles verticle movement. UP and DOWN movement with camera.
    /// </summary>
    private void ChangeCameraRotation()
    {
        //Sets the new Y value of the rotation of the camera and wraps the angle to keep it osscilating from -1 to 1
        float newCameraYValue = WrapAngle(cameraTransform.localEulerAngles.x + -Input.GetAxis("Mouse Y") * Time.deltaTime * YSensitivity);

        //Performs the actual transformation and clamps values.
        cameraTransform.localEulerAngles = new Vector3(Mathf.Clamp(newCameraYValue, -85, 85), cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.y);
    }

    //To change angles from + 350 to -10
    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    /// <summary>
    /// horizontal control of player and camera
    /// </summary>
    private void ChangePlayerRotation()
    {
        //chnages rotation based on x-axis that can be found in edit -> project settings -> Input manager.
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * XSensitivity, transform.eulerAngles.z);
    }
}
