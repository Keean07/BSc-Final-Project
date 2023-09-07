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

    void Start()
    {
        menuManager = MenuManager.GetComponent<MenuManager>();
        platformManager = PlatformManager.GetComponent<PlatformManager>();
        playerManager = PlayerManager.GetComponent<PlayerManager>();
        coinManager = CoinManager.GetComponent<CoinManager>();

        // Begin Gameplay loop with welcome screen
        menuManager.WelcomeScreen();
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(1.0f / Time.deltaTime);
        // Close welcome message and begin gameplay
        if (Input.anyKey && menuManager.welcomeScreen)
        {
            menuManager.BeginGameplay();
            Time.timeScale = 1f;
        }

        // Open pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !menuManager.gameOverScreen && !menuManager.optionsScreen && !menuManager.pauseScreen && !menuManager.diedScreen && !menuManager.progressScreen)
        {
            menuManager.PauseGameplay();
            Time.timeScale = 0;
        }

        // Close pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && (menuManager.pauseScreen || menuManager.optionsScreen))
        {
            menuManager.ResumeGameplay();
            Time.timeScale = 1;
        }

        // If player falls off platform
        if (playerManager.player.transform.position.y < platformManager.currentPlatform.transform.position.y - 3)
        {
            if (!menuManager.gameOverScreen && !menuManager.diedScreen) 
            {
                // If player still has lives
                if (playerManager.playerLives > 0)
                {
                    menuManager.PlayerDied();
                }
                // If player is out of lives
                else if (playerManager.playerLives == 0)
                {
                    menuManager.GameOver(CoinManager.GetComponent<CoinManager>().score);
                }
                //Time.timeScale = 0;
            }
        }

        // Respawn player
        if (menuManager.diedScreen && Input.GetKeyDown(KeyCode.Return))
        {
            platformManager.RestartPlatform();
            platformManager.ResetPlayer();
            menuManager.PlayerRespawn();
            Time.timeScale = 1;
        }

        // Pause gameplay when completed platform
        if (!coinManager.GetComponent<CoinManager>().remaining && !menuManager.progressScreen)
        {
            menuManager.PlayerProgess();
            Time.timeScale = 0;
        }

        // Player begins next platform
        if (menuManager.progressScreen && Input.GetKeyDown(KeyCode.Return))
        {
            platformManager.RestartPlatform();
            platformManager.ResetPlayer();
            menuManager.BeginNext();
            coinManager.CheckCoins();
            Time.timeScale = 1;
        }
    }

    public void PlayerProgress()
    {
        platformManager.NextPlatform();
        coinManager.currentPlatform = platformManager.currentPlatform;
    }
}
