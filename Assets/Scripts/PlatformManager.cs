using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //[SerializeField] private GameObject MenuManager;
    //[SerializeField] private GameObject PlayerManager;
    //[SerializeField] private GameObject GameManager;
    //[SerializeField] private GameObject CoinManager;

    [SerializeField] private GameObject CameraManager;
    private CameraManager cameraManager;

    [SerializeField] GameObject player;
    [SerializeField] public GameObject platform1;
    [SerializeField] GameObject platform2;

    public GameObject currentPlatform;

    private List<GameObject> platformList;

    private CoinSpawner coinSpawner1;

    private Vector3 Spawn1;
    private Vector3 Spawn2;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = platform1;

        platformList.Add(platform1);
        platformList.Add(platform2);

        coinSpawner1 = platform1.GetComponent<CoinSpawner>();
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


}
