using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class GameplayManager: MonoBehaviour
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

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platform;

    // Here are all my flags:
    //private bool restart;
    private bool gameOverScreen;

    private int points;
    private EventSystem eventSystem;
    private EventSystem firstSelectedButton;

    void Start()
    {
        eventSystem = EventSystem.current;
        firstSelectedButton = eventSystem.GetComponent<EventSystem>();

        restartButton.onClick.AddListener(restartGame);
        quitToMainButton.onClick.AddListener(quitToMain);

        gameOverScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            beginGameplay();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverScreen)
        {
            pauseGameplay();
        }

        if (player.transform.position.y < 0 && !gameOverScreen)
        {
            points = platform.GetComponent<CoinSpawner>().score;
            gameOver(points);
            //restart = true;
        }

        //if (restart == true)
        //{
        //    if (Input.GetKeyDown("r"))
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //    }
        //}
    }

    private void beginGameplay()
    {
        welcomePanel.SetActive(false);
    }

    private void pauseGameplay()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void resumeGameplay()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    private void gameOver(int score)
    {
        gameOverText.text = ("Game Over. You got a score of " + score + " : Press \"R\" to restart");
        gameOverPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(restartButtonObject, new BaseEventData(eventSystem));
        gameOverScreen = true;
    }

    private void restartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void quitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
