using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TMP_Text gameOverText;
    [SerializeField]
    private GameObject restartButtonObject;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private GameObject quitToMainButtonObject;
    [SerializeField]
    private Button quitToMainButton;

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject optionsPanel;
    [SerializeField]
    private GameObject confirmQuitPanel;

    // Here are all my flags:
    //private bool restart;
    public bool gameOverScreen;

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

        gameOverScreen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginGameplay()
    {
        welcomePanel.SetActive(false);
    }

    public void PauseGameplay()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGameplay()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void GameOver(int score)
    {
        gameOverText.text = ("Game Over. You got a score of " + score + " : Restart or Quit?");
        gameOverPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(restartButtonObject, new BaseEventData(eventSystem));
        gameOverScreen = true;
        //restart = true;
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
