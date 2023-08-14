using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager: MonoBehaviour
{
    [SerializeField] private GameObject MenuManager;
    [SerializeField] private GameObject PlayerManager;
    [SerializeField] private GameObject PlatformManager;
    [SerializeField] private GameObject CoinManager;

    private MenuManager menuManager;
    private PlayerManager playerManager;
    private PlatformManager platformManager;
    private CoinManager coinManager;

    // Here are all my flags:
    private int points;

    void Start()
    {
        menuManager = MenuManager.GetComponent<MenuManager>();
        platformManager = PlatformManager.GetComponent<PlatformManager>();
        playerManager = PlayerManager.GetComponent<PlayerManager>();
        coinManager = CoinManager.GetComponent<CoinManager>();
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

        if (playerManager.player.transform.position.y < platformManager.currentPlatform.transform.position.y - 10 && playerManager.playerLives > 0)
        {
            platformManager.RestartPlatform();
            playerManager.playerLives--;
            menuManager.PlayerDied(playerManager.playerLives);
        }

        if (playerManager.playerLives == 0 && playerManager.player.transform.position.y < 0 && !menuManager.gameOverScreen)
        {
            menuManager.GameOver(CoinManager.GetComponent<CoinSpawner>().score);
        }

        if (menuManager.diedScreen && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            menuManager.PlayerRespawn();
        }
    }
}
