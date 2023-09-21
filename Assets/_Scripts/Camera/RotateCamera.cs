using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] PlatformManager platformManager;

    public float rotationSpeed = 2f;

    private Vector3 pivotPoint;
    private Vector2 startMousePosition;
    private Vector2 currentMousePosition;
    private bool isRotating = false;

    public float rotationY;
    public float rotationX;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        pivotPoint = platformManager.currentPlatform.transform.position;
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            Vector2 delta = currentMousePosition - startMousePosition;
            rotationX = delta.y * rotationSpeed;
            rotationY = delta.x * rotationSpeed;

            //Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);
            if (Mouse.current.position.ReadValue() != currentMousePosition)
            {
                RotateCam(rotationX, rotationY);
            }
            else
            {
                StartRotation(Mouse.current.position.ReadValue());
            }
            currentMousePosition = Mouse.current.position.ReadValue();
        }
    }
    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                StartRotation(Mouse.current.position.ReadValue());
                break;
            case InputActionPhase.Canceled:
                EndRotation();
                break;
        }
    }

    public void RotateCam(float rotationX, float rotationY)
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

}
