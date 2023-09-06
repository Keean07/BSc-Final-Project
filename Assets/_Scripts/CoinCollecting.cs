using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;
    [SerializeField] AudioManager audioManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("coin"))
        {
            audioManager.CollectSound();
            coinManager.RemoveCoin(collider);
        }
    }
}
