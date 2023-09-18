using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    [HideInInspector] public bool reset;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        reset = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!reset)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
                
            Vector3 moveBall = new(horizontal, 0, vertical);

            rb.AddForce(moveBall * speed);
            //Debug.Log("Adding force");
        }
    }

    public void ResetPlayer(GameObject currentPlatform)
    {
        // Reset player position on current platform
        transform.position = currentPlatform.transform.position + new Vector3(0f, 5f, 0f);
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

}
