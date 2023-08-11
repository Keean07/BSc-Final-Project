using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager: MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;

    // Here are all my flags:
    private int points;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            menuManager.BeginGameplay();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !menuManager.gameOverScreen && !menuManager.optionsScreen && !menuManager.pauseScreen)
        {
            menuManager.PauseGameplay();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (menuManager.pauseScreen || menuManager.optionsScreen))
        {
            menuManager.ResumeGameplay();
        }

        if (player.transform.position.y < 0 && !menuManager.gameOverScreen)
        {
            points = platform.GetComponent<CoinSpawner>().score;
            menuManager.GameOver(points);
        }
    }
}
