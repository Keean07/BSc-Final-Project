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
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private BallMoving ballMoving;

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
            PlayerDied();
        }

        // Respawn player
        if (menuManager.diedScreen && Input.GetKeyDown(KeyCode.Return))
        {
            RespawnPlayer();
        }

        // Player begins next platform
        if (menuManager.progressScreen && Input.GetKeyDown(KeyCode.Return))
        {
            BeginNextPlatform();
        }
    }

    private void PlayerDied()
    {
        if (!menuManager.gameOverScreen && !menuManager.diedScreen && !menuManager.progressScreen)
        {
            // If player still has lives
            if (playerManager.playerLives > 0)
            {
                menuManager.PlayerDied();
            }
            // If player is out of lives
            else if (playerManager.playerLives < 1)
            {
                menuManager.GameOver(CoinManager.GetComponent<CoinManager>().score);
            }
        }
    }

    public void PlayerProgress()
    {
        // Set flag
        ballMoving.reset = true;
        // Check if there is another platform
        if (platformManager.NextPlatform())
        {
            // Reset player position, velocity, and angular velocity
            //ballMoving.CancelForce();
            // Move Camera
            cameraManager.CamToPlatform(platformManager.currentPlatform);
            // Set Coin Manager's current platform
            coinManager.currentPlatform = platformManager.currentPlatform;
            // Fill new coins
            coinManager.FillCoinsList();
            // Check coins
            coinManager.CheckCoins();
            // Enable relevant panel
            menuManager.PlayerProgess();
        } else
        {
            PlayerWins();
        }
        // Stop time
        Time.timeScale = 0;
    }

    private void BeginNextPlatform()
    {
        //platformManager.RestartPlatform();
        menuManager.BeginNext();
        Time.timeScale = 1;
        ballMoving.ResetPlayer(platformManager.currentPlatform);
        ballMoving.reset = false;
    }

    private void RespawnPlayer()
    {
        platformManager.RestartPlatform();
        ballMoving.ResetPlayer(platformManager.currentPlatform);
        menuManager.PlayerRespawn();
        Time.timeScale = 1;
    }

    private void PlayerWins()
    {
        menuManager.Victory();
        Time.timeScale = 0;
    }
}
