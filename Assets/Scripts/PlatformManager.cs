using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject CameraManager;
    private CameraManager cameraManager;

    [SerializeField] GameObject player;
    [SerializeField] GameObject platform1;
    [SerializeField] GameObject platform2;

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
            platform2
        };

        cameraManager = CameraManager.GetComponent<CameraManager>();
        Spawn1 = new Vector3(0.0f, 11.0f, 0.0f);
        Spawn2 = new Vector3(0.0f, 22.0f, 11.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextPlatform()
    {
        if (currentPlatform == platform1)
        {
            player.transform.position = Spawn2;
            cameraManager.CamToPlatform(2);

        }
        currentPlatform = platform2;
    }

    public void RestartPlatform()
    {
        player.transform.position = currentPlatform.transform.position + new Vector3(0, 5, 0);
    }
}
