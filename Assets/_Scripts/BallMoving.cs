using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveBall = new(horizontal, 0, vertical);

        rb.AddForce(moveBall * speed);
    }

    public void ResetPlayer(GameObject currentPlatform)
    {
        // Reset player velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        // Reset player angular velocity
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        // Sleep rigidbody
        GetComponent<Rigidbody>().Sleep();

        // Reset player position
        transform.position = new Vector3(
            currentPlatform.transform.position.x,
            currentPlatform.transform.position.y + 5,
            currentPlatform.transform.position.z
            );
    }

}
