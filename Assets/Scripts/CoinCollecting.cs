using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] CoinManager CoinManager;
    private CoinSpawner coinSpawner;

    // Start is called before the first frame update
    void Start()
    {
        coinSpawner = CoinManager.GetComponent<CoinSpawner>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("coin"))
        {
            coinSpawner.RemoveCoin(collider);
        }
    }
}
