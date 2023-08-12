using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] TMP_Text pointsText;
    [SerializeField] TMP_Text livesText;

    public int playerLives;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + coinSpawner.score;
        livesText.text = "LivesL " + playerLives;
    }

}
