using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] PlatformManager platformManager;

    public float rotationSpeed = 2f;

    public Vector3 pivotPoint;
    private bool isRotating = false;

    public float rotationY;
    public float rotationX;

    private float rotationDirection;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Set first pivot point
        pivotPoint = platformManager.currentPlatform.transform.position;
        cam = Camera.main;

    }

    private void FixedUpdate()
    {
        // If user is rotating cam, rotate cam around pivot
        if (isRotating)
        {
            // If player presses ','
            if (rotationDirection == -1)
            {
                rotationY = -rotationDirection * rotationSpeed;
            }
            else if (rotationDirection == 1)
            {
                // Times calculate amount to rotate by and invert it to correct direction
                rotationY = -rotationDirection * rotationSpeed;
            }
            RotateCam(rotationY);
        }
    }

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                rotationDirection = context.ReadValue<float>();
                Debug.Log(rotationDirection);
                isRotating = true;
                break;
            case InputActionPhase.Canceled:
                isRotating= false;
                break;
            
        }
    }

    public void RotateCam(float rotationY)
    {
        //cam.transform.RotateAround(pivotPoint, Vector3.left, rotationX * Time.deltaTime);
        cam.transform.RotateAround(pivotPoint, Vector3.up, rotationY * Time.deltaTime);
    }

    public Quaternion GetCamRotation()
    {
        return cam.transform.rotation;
    }

    public Vector3 GetCameraForward()
    {
        return cam.transform.forward;
    }

    public Vector3 GetCameraRight()
    {
        return cam.transform.right;
    }

}
