﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    public List<GameObject> coinsList;

    private GameObject child;

    public int score;

    public TMP_Text pointsText;

    private float rotatespeed = 120;

    private Vector3 rotationDirection = new Vector3(0, 0, 1);

    private Vector3 Spawn1;
    private Vector3 Spawn2;


    // Start is called before the first frame update
    void Start()
    {
        Spawn1 = new Vector3 (0.0f, 11.0f, 0.0f);
        Spawn1 = new Vector3 (0.0f, 20.0f, 11.5f);
        coinsList = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            child = transform.GetChild(i).gameObject;
            coinsList.Add(child);
        }

        InvokeRepeating("CheckCoins", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < coinsList.Count; i++)
        {
            coinsList[i].transform.Rotate(rotatespeed * rotationDirection * Time.deltaTime);
        }
        pointsText.text = "Points: " + score;
    }

    void CheckCoins()
    {
        bool remaining = false;

        for (int i = 0; i < coinsList.Count; i++)
        {
            if (coinsList[i].activeSelf == true)
            {
                remaining = true;
            }
        }

        if (remaining == false)
        {
            Debug.Log("Opening Portal");
            //this.GameObject.transform.position = Spawn2;

            //for (int i = 0; i < coinsList.Count; i++)
            //{
            //    coinsList[i].SetActive(true);
            //}
        }
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
    }
}