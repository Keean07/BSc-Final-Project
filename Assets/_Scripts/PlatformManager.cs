using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject CameraManager;
    private CameraManager cameraManager;

    [SerializeField] GameObject player;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;
    [SerializeField] GameObject platform3;

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
            platform3
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
        }
        cameraManager.CamToPlatform(currentPlatform);
        ResetPlayer();
    }
    // Move player ball to the center of current platform and remove any current velocity
    public void RestartPlatform()
    {
        // Reset platform angular velocity
        currentPlatform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        // Reset platform rotation
        currentPlatform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        // Reset player position
        player.transform.position = new Vector3(
            currentPlatform.transform.position.x,
            currentPlatform.transform.position.y + 5,
            currentPlatform.transform.position.z
            );
        // Reset player velocity
        player.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        // Reset player angular velocity
        player.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
