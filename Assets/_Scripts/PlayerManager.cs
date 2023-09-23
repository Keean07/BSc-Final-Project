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
    public int playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = 3;
        UpdateStats();
    }

    public void LoseLife()
    {
        playerLives--;
        UpdateStats();
    }

    public void GetLife()
    {
        playerLives++;
        UpdateStats();
    }

    public void GetPoint()
    {
        playerScore++;
        UpdateStats();
    }

    public void UpdateStats()
    {
        pointsText.text = "Points: " + playerScore;
        livesText.text = "Lives: " + playerLives;
    }

}
