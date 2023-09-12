using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject restartButtonObject;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pausePanelResumeButtonObject;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsPanelBackButtonObject;

    [SerializeField] private GameObject confirmQuitPanel;
    [SerializeField] private GameObject cancelQuitButton;

    [SerializeField] private GameObject diedPanel;
    [SerializeField] private TMP_Text playerDiedText;

    [SerializeField] private GameObject progressPanel;

    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject victoryRestartButton;

    [SerializeField] PlayerManager playerManager;
    [SerializeField] AudioManager audioManager;

    // Here are all my flags:
    //private bool restart;
    public bool gameOverScreen;
    public bool optionsScreen;
    public bool pauseScreen;
    public bool diedScreen;
    public bool progressScreen;
    public bool welcomeScreen;
    public bool victoryScreen;

    //private int points;
    private EventSystem eventSystem;
    private EventSystem firstSelectedButton;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        firstSelectedButton = eventSystem.GetComponent<EventSystem>();

        gameOverScreen = false;
        optionsScreen = false;
        pauseScreen = false;
        diedScreen = false;
        progressScreen = false;
        welcomeScreen = false;
        victoryScreen = false;

    }

    public void WelcomeScreen()
    {
        welcomePanel.SetActive(true);
        welcomeScreen = true;
    }

    public void BeginGameplay()
    {
        welcomePanel.SetActive(false);

        welcomeScreen = false;
    }

    public void PauseGameplay()
    {
        pausePanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(pausePanelResumeButtonObject, new BaseEventData(eventSystem));
    }

    public void ResumeGameplay()
    {
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
        playerManager.LoseLife();
        audioManager.DeathSound();
        playerDiedText.text = "YOU DIED..\r\nYOU HAVE " + playerManager.playerLives + " LIVES LEFT\r\nPRESS ENTER TO START AGAIN";
        diedPanel.SetActive(true);
        diedScreen = true;
    }

    public void PlayerRespawn()
    {
        diedPanel.SetActive(false);
        diedScreen = false;
    }

    public void PlayerProgess()
    {
        audioManager.ProgressSound();
        progressPanel.SetActive(true);
        progressScreen = true;
    }

    public void BeginNext()
    {
        progressPanel.SetActive(false);
        progressScreen = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ConfirmQuit()
    {
        pausePanel.SetActive(false);
        confirmQuitPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(cancelQuitButton, new BaseEventData(eventSystem));
    }

    public void CancelQuit()
    {
        confirmQuitPanel.SetActive(false);
        pausePanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(pausePanelResumeButtonObject, new BaseEventData(eventSystem));
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        victoryScreen = true;
        firstSelectedButton.SetSelectedGameObject(victoryRestartButton, new BaseEventData(eventSystem));
    }
}
