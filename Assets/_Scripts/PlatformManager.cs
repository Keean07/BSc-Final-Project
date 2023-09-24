using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject CameraManager;
    [SerializeField] private BallMoving ballMoving;

    [SerializeField] GameObject player;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    [SerializeField] GameObject platform3;
    [SerializeField] GameObject platform4;
    [SerializeField] GameObject platform5;
    [SerializeField] GameObject platform6;
    [SerializeField] GameObject platform7;

    [HideInInspector] public GameObject currentPlatform;

    private int platIndex = 0;

    private List<GameObject> platformList;

    private Rigidbody currentRB;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = platform1;
        currentRB = currentPlatform.GetComponent<Rigidbody>();

        platformList = new List<GameObject>
        {
            platform1,
            platform2,
            platform3,
            platform4,
            platform5,
            platform6,
            platform7
        };

        //Spawn1 = new Vector3(0.0f, 11.0f, 0.0f);
        //Spawn2 = new Vector3(0.0f, 22.0f, 11.0f);
    }

    // Move player and camera to new platform location
    public bool NextPlatform()
    {
        if (platIndex < platformList.Count - 1)
        {
            platIndex++;
            currentPlatform = platformList[platIndex];
            currentRB = currentPlatform.GetComponent<Rigidbody>();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RestartPlatform()
    {
        // Reset platform velocity
        currentRB.velocity = Vector3.zero;
        // Reset platform angular velocity
        currentRB.angularVelocity = Vector3.zero;
        // Reset platform rotation
        currentPlatform.transform.rotation = Quaternion.identity;
        Debug.Log("Reset platform");
    }
}
