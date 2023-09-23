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
    private Vector2 startMousePosition;
    private Vector2 currentMousePosition;
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

    // Update is called once per frame
    //void Update()
    //{
    //    // If user is rotating cam, rotate cam around pivot
    //    if (isRotating)
    //    {

    //        //// Get mouse movement and calculate rotation values therefrom
    //        //Vector2 delta = currentMousePosition - startMousePosition;
    //        //rotationX = delta.y * rotationSpeed;
    //        //rotationY = delta.x * rotationSpeed;

    //        //RotateCam(rotationY);
    //        //currentMousePosition = Mouse.current.position.ReadValue();

    //        // If player presses ','
    //        if (rotationDirection == -1)
    //        {
    //            rotationY = rotationDirection * rotationSpeed * Time.deltaTime;
    //        } else if (rotationDirection == 1) 
    //        {
    //            // Times calculate amount to rotate by and invert it to correct direction
    //            rotationY = -rotationDirection * rotationSpeed * Time.deltaTime;
    //        }
    //        RotateCam(rotationY);
    //    }

    //}

    private void FixedUpdate()
    {
        // If user is rotating cam, rotate cam around pivot
        if (isRotating)
        {

            //// Get mouse movement and calculate rotation values therefrom
            //Vector2 delta = currentMousePosition - startMousePosition;
            //rotationX = delta.y * rotationSpeed;
            //rotationY = delta.x * rotationSpeed;

            //RotateCam(rotationY);
            //currentMousePosition = Mouse.current.position.ReadValue();

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


        //switch (context.phase)
        //{
        //    case InputActionPhase.Started:
        //        StartRotation(Mouse.current.position.ReadValue());
        //        break;
        //    case InputActionPhase.Canceled:
        //        EndRotation();
        //        break;
        //}
    }

    public void RotateCam(float rotationY)
    {
        //cam.transform.RotateAround(pivotPoint, Vector3.left, rotationX * Time.deltaTime);
        cam.transform.RotateAround(pivotPoint, Vector3.up, rotationY * Time.deltaTime);
    }

    private void StartRotation(Vector2 mousePosition)
    {
        isRotating = true;
        //Debug.Log("Started at: " + mousePosition);
        startMousePosition = mousePosition;
        currentMousePosition = mousePosition;
    }

    private void EndRotation()
    {
        isRotating = false;
        //Debug.Log("Ended");
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
