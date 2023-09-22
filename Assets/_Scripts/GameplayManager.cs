using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager: MonoBehaviour
{
    [SerializeField] private BallMoving ballMoving;
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private GameSettingImporter gameSettingImporter;

    private int maxDistUnderPlatform = 3;

    void Start()
    {
        gameSettingImporter = FindObjectOfType<GameSettingImporter>();

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
            BeginGameplay();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Resume Gameplay
            if (!menuManager.playing && (menuManager.pauseScreen || menuManager.optionsScreen))
            {
                Debug.Log("Resuming");
                ResumeGameplay();
            }
            //Pause Gameplay
            else if (menuManager.playing)
            {
                Debug.Log("Pausing");
                PauseGameplay();
            }
        }

        // If player falls off platform
        if (playerManager.player.transform.position.y < platformManager.currentPlatform.transform.position.y - maxDistUnderPlatform)
        {
            PlayerDied();
            ballMoving.landed = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Respawn Player
            if (menuManager.diedScreen)
            {
                RespawnPlayer();
            }
            // Begin next platform
            else if (menuManager.progressScreen)
            {
                BeginNextPlatform();
                ballMoving.landed = false;
            }
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
                menuManager.GameOver(coinManager.score);
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
    }
    public void BeginGameplay()
    {
        menuManager.BeginGameplay();
        Time.timeScale = 1f;
    }
    public void ResumeGameplay()
    {
        menuManager.ResumeGameplay();
        Time.timeScale = 1;
    }

    public void PauseGameplay()
    {
        menuManager.PauseGameplay();
        Time.timeScale = 0;
    }

    private void BeginNextPlatform()
    {
        //platformManager.RestartPlatform();
        menuManager.BeginNext();
        ballMoving.ResetPlayer(platformManager.currentPlatform);
        ballMoving.reset = false;
    }

    public void RespawnPlayer()
    {
        platformManager.RestartPlatform();
        ballMoving.ResetPlayer(platformManager.currentPlatform);
        menuManager.PlayerRespawn();
        ballMoving.landed = false;
        Time.timeScale = 1;
    }

    private void PlayerWins()
    {
        menuManager.Victory();
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        gameSettingImporter.SaveGameSettings();
        SceneManager.LoadScene(1);
    }

    public void QuitToMain() 
    {
        gameSettingImporter.SaveGameSettings();
        SceneManager.LoadScene(0);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
