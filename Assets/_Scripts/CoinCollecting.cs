using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("coin"))
        {
            coinManager.RemoveCoin(collider);
        }
    }
}
