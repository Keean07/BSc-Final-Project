using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    [SerializeField] CoinManager coinManager;
    [SerializeField] AudioManager audioManager;
    [SerializeField] PlayerManager playerManager;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("coin"))
        {
            audioManager.CollectCoinSound();
            coinManager.RemoveCoin(collider);
        }

        if (collider.CompareTag("Health"))
        {
            audioManager.CollectHealthSound();
            coinManager.RemoveCoin(collider);
        }
    }
}
