using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private CoinManager coinManager;
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
        pointsText.text = "Points: " + coinManager.score;
        livesText.text = "Lives: " + playerLives;
    }

}
