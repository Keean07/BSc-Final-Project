﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMoving : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private RotateCamera rotateCamera;
    [HideInInspector] public bool reset;

    private Rigidbody rb;
    public float speed = 800;
    public float jumpForce = 6f;

    // Flag to prevent landing sounds continuously playing
    public bool landed = false;
    private bool canJump;

    private Vector3 moveVec = Vector3.zero;
    private Vector3 inputVec = Vector3.zero;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        reset = false;
        canJump = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!reset)
        {
            // Get cameras forward direction
            Vector3 cameraForward = rotateCamera.GetCameraForward();
            // Ignore y direction
            cameraForward.y = 0;
            // Normalize
            cameraForward.Normalize();
            // Calculate the direction the ball must be going based on user input
            moveDirection = cameraForward * inputVec.y + rotateCamera.GetCameraRight() * inputVec.x;
            moveVec = moveDirection.normalized * speed;

            //moveVec = new Vector3(inputVec.x, 0, inputVec.y) * speed;

            if (!canJump)
            {
                moveVec /= 2;
            }
            rb.AddForce(moveVec * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVec = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            landed = false;
        }
    }

    public void ResetPlayer(GameObject currentPlatform)
    {
        // Reset player position on current platform
        transform.position = currentPlatform.transform.position + new Vector3(0f, 3f, 0f);
        // Reset player velocity
        CancelForce();
    }

    public void CancelForce()
    {
        // Reset player velocity
        rb.velocity = Vector3.zero;
        // Reset player angular velocity
        rb.angularVelocity = Vector3.zero;
        // Reset rotation
        transform.rotation = Quaternion.identity;
        // Sleep rigidbody
        rb.Sleep();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && !landed)
        {
            if (collision.gameObject == platformManager.currentPlatform)
            {
                audioManager.LandingSound();
                landed = true;
                canJump = true;
            }
        }
    }

}
