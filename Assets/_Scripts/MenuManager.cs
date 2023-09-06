using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    //[SerializeField] private GameObject GameManager;
    //[SerializeField] private GameObject PlatformManager;
    //[SerializeField] private GameObject CoinManager;

    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject restartButtonObject;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject quitToMainButtonObject;
    [SerializeField] private Button quitToMainButton;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pausePanelResumeButtonObject;
    [SerializeField] private Button pausePanelResumeButton;
    [SerializeField] private Button pausePanelOptionButtonObject;
    [SerializeField] private Button pausePanelOptionsButton;
    [SerializeField] private Button pausePanelQuitButtonObject;
    [SerializeField] private Button pausePanelQuitButton;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsPanelBackButtonObject;
    [SerializeField] private Button optionsPanelBackButton;
    [SerializeField] private GameObject confirmQuitPanel;

    [SerializeField] private GameObject diedPanel;
    [SerializeField] private TMP_Text playerDiedText;

    [SerializeField] private GameObject progressPanel;

    [SerializeField] PlayerManager playerManager;
    [SerializeField] AudioManager audioManager;

    // Here are all my flags:
    //private bool restart;
    public bool gameOverScreen;
    public bool optionsScreen;
    public bool pauseScreen;
    public bool diedScreen;
    public bool progressScreen;

    public bool living;

    //private int points;
    private EventSystem eventSystem;
    private EventSystem firstSelectedButton;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        firstSelectedButton = eventSystem.GetComponent<EventSystem>();

        restartButton.onClick.AddListener(RestartGame);
        quitToMainButton.onClick.AddListener(QuitToMain);
        pausePanelResumeButton.onClick.AddListener(ResumeGameplay);
        pausePanelOptionsButton.onClick.AddListener(OpenOptions);
        optionsPanelBackButton.onClick.AddListener(CloseOption);

        gameOverScreen = false;
        optionsScreen = false;
        pauseScreen = false;
        diedScreen = false;
        progressScreen = false;
    }

    public void BeginGameplay()
    {
        living = true;
        welcomePanel.SetActive(false);
    }

    public void PauseGameplay()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(pausePanelResumeButtonObject, new BaseEventData(eventSystem));
    }

    public void ResumeGameplay()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        pauseScreen = false;
        optionsScreen= false;
    }

    public void GameOver(int score)
    {
        gameOverText.text = ("Game Over. You got a score of " + score + " : Restart or Quit?");
        gameOverPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(restartButtonObject, new BaseEventData(eventSystem));
        gameOverScreen = true;
    }

    public void OpenOptions()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(optionsPanelBackButtonObject, new BaseEventData(eventSystem));
        optionsScreen = true;
        pauseScreen = false;
    }

    public void CloseOption()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(pausePanelResumeButtonObject, new BaseEventData(eventSystem));
        pauseScreen = true;
        optionsScreen = false;
    }

    public void PlayerDied()
    {
        playerManager.playerLives--;
        Debug.Log(playerManager.playerLives);
        audioManager.DeathSound();
        playerDiedText.text = "YOU DIED..\r\nYOU HAVE " + playerManager.playerLives + " LIVES LEFT\r\nPRESS ENTER TO START AGAIN";
        diedPanel.SetActive(true);
        diedScreen = true;
        //Time.timeScale = 0;
        living = false;
    }

    public void PlayerRespawn()
    {
        diedPanel.SetActive(false);
        diedScreen = false;
        living = true;
        Time.timeScale = 1;
    }

    public void PlayerProgess()
    {
        audioManager.ProgressSound();
        Time.timeScale = 0;
        progressPanel.SetActive(true);
        progressScreen = true;
    }

    public void BeginNext()
    {
        progressPanel.SetActive(false);
        progressScreen = false;
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
