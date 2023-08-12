using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //[SerializeField] private GameObject MenuManager;
    //[SerializeField] private GameObject PlayerManager;
    //[SerializeField] private GameObject GameManager;
    //[SerializeField] private GameObject CoinManager;

    [SerializeField] GameObject player;
    [SerializeField] public GameObject platform1;
    [SerializeField] GameObject platform2;

    private CoinSpawner coinSpawner1;

    private Vector3 Spawn1;
    private Vector3 Spawn2;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawner1 = platform1.GetComponent<CoinSpawner>();
        Spawn1 = new Vector3(0.0f, 11.0f, 0.0f);
        Spawn1 = new Vector3(0.0f, 20.0f, 11.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Platform1to2()
    {
        player.transform.position = Spawn2;
    }


}
