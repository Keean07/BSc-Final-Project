using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject CameraManager;
    [SerializeField] private BallMoving ballMoving;
    private CameraManager cameraManager;

    [SerializeField] GameObject player;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    [SerializeField] GameObject platform3;
    [SerializeField] GameObject platform4;
    [SerializeField] GameObject platform5;
    [SerializeField] GameObject platform6;

    [HideInInspector] public GameObject currentPlatform;

    private List<GameObject> platformList;

    private Vector3 Spawn1;
    private Vector3 Spawn2;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = platform1;

        platformList = new List<GameObject>
        {
            platform1,
            platform2,
            platform3,
            platform4,
            platform5,
            platform6
        };

        cameraManager = CameraManager.GetComponent<CameraManager>();
        Spawn1 = new Vector3(0.0f, 11.0f, 0.0f);
        Spawn2 = new Vector3(0.0f, 22.0f, 11.0f);
    }

    // Move player and camera to new platform location
    public void NextPlatform()
    {
        if (currentPlatform == platform1)
        {
            currentPlatform = platform2;
        } else if (currentPlatform == platform2)
        {
            currentPlatform = platform3;
        } else if (currentPlatform == platform3)
        {
            currentPlatform = platform4;
        } else if (currentPlatform == platform4)
        {
            currentPlatform = platform5;
        } else if (currentPlatform == platform5)
        {
            currentPlatform = platform6;
        }
        cameraManager.CamToPlatform(currentPlatform);
        ballMoving.ResetPlayer(currentPlatform);
    }
    // Move player ball to the center of current platform and remove any current velocity
    public void RestartPlatform()
    {
        // Reset platform angular velocity
        currentPlatform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        // Reset platform rotation
        currentPlatform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public void ResetPlayer()
    {

    }
}
