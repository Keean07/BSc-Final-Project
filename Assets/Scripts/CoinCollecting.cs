using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private CoinSpawner coinSpawner;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawner = platform.GetComponent<CoinSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "coin")
        {
            //Debug.Log("Got coin");
            coinSpawner.RemoveCoin(collider);
        }
    }
}
