using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    private GameObject player;
    public float speed;
    //private bool jump;

    void Start()
    {
        player = GetComponent<PlayerManager>().player;
        //jump = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetButtonDown("Jump"))
        //{

        //    //jump = true;
        //    Debug.Log("Jump");
        //}

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveBall = new Vector3(horizontal, 0, vertical);

        Rigidbody rb = player.transform.GetComponent<Rigidbody>();
        rb.AddForce(moveBall * speed);
    }

    //void isGrounded()
    //{

    //}
}
