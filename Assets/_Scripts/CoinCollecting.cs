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
            audioManager.CollectSound();
            coinManager.RemoveCoin(collider);
        }

        if (collider.CompareTag("Health"))
        {
            Debug.Log("Life added");
            coinManager.RemoveCoin(collider);
        }
    }
}
