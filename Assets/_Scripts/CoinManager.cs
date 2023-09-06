using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject health;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private PlayerManager playerManager;

    private GameObject currentPlatform;

    public List<GameObject> coinsList;

    public List<GameObject> healthList;

    private GameObject child;

    public int score;

    private readonly float rotatespeed = 120;

    private Vector3 rotationDirection = new(0, 0, 1);

    public bool remaining;


    // Start is called before the first frame update
    void Start()
    {
        remaining = true;
        // Save current platform from platform manager script
        currentPlatform = platformManager.currentPlatform;
        // Create list to store coins
        coinsList = new List<GameObject>();

        // Create list to store health pickups
        healthList = new List<GameObject>();

        // Clear and fill coins list with platforms coins
        FillCoinsList();

        // Call CheckCoins after 1 second, and then every 1 second
        InvokeRepeating(nameof(CheckCoins), 1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateCoins();
    }

    private void FillCoinsList()
    {
        // Fill coins list with platforms children (the coins)
        for (int i = 0; i < currentPlatform.transform.childCount; i++)
        {
            child = currentPlatform.transform.GetChild(i).gameObject;
            if (child.CompareTag("coin")) {
                coinsList.Add(child);
            } 
            else if (child.CompareTag("Health"))
            {
                healthList.Add(child);
            }
        }
    }

    private void RotateCoins()
    {
        for (int i = 0; i < coinsList.Count; i++)
        {
            coinsList[i].transform.Rotate(rotatespeed * rotationDirection * Time.deltaTime);
        }
        
        for (int i = 0; i < healthList.Count; i++)
        {
            healthList[i].transform.Rotate(rotatespeed * rotationDirection * Time.deltaTime);
        }
    }

    public void CheckCoins()
    {        
        for (int i = 0; i < coinsList.Count; i++)
        {
            if (coinsList[i].activeSelf == true)
            {
                remaining = true;
                break;
            }
            else
            {
                remaining = false;
            }
        }

        if (remaining == false)
        {
            coinsList.Clear();
            ChangePlatform();
        }
    }

    public void ChangePlatform()
    {
        platformManager.NextPlatform();
        currentPlatform = platformManager.currentPlatform;
        FillCoinsList();
    }

    /***
     * SpawnCoin is used to spawn in coins at specific coordinates
     */
    private void SpawnCoin()
    {
        //// Create Coordinates
        //float xpos = (float)rnd.Next(-2, 3);
        //float zpos = (float)rnd.Next(-2, 3);
        //float ypos = 0.35f;

        //// Create Position Vector
        //Vector3 coinPos = new Vector3(xpos, ypos, zpos);

        //// Create Rotation Vector
        //Vector3 coinRotation = new Vector3(90, 0, 0);

        //// Create new coin
        //GameObject newCoin = Instantiate(coin, transform.position + coinPos, coin.transform.rotation);

        //// Give coin name
        //newCoin.name = "Coin" + (coinsList.Count + 1);

        //// Add coin to coins list
        //coinsList.Add(newCoin);
    }

    public void RemoveCoin(Collider collider)
    {
        for (int i = 0; i < coinsList.Count;i++)
        {
            if (collider.gameObject == coinsList[i])
            {
                coinsList[i].SetActive(false);
                score++;
            }
        }
        
        for (int i = 0; i < healthList.Count;i++)
        {
            if (collider.gameObject == healthList[i])
            {
                healthList[i].SetActive(false);
                playerManager.playerLives++;
            }
        }
    }
}