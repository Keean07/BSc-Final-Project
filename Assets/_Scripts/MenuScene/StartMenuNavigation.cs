using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMenuNavigation : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject startButtonObject;
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private GameObject cancelExitButtonObject;
    [SerializeField] private Button cancelExitButton;
    [SerializeField] private GameObject confirmExitButtonObject;
    [SerializeField] private Button confirmExitButton;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsBackButtonObject;
    [SerializeField] private Button optionsBackButton;

    private EventSystem eventSystem;
    private EventSystem firstSelectedButton;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;

        startButton.onClick.AddListener(LoadGame);
        exitButton.onClick.AddListener(RequestQuit);
        cancelExitButton.onClick.AddListener(CancelQuit);
        confirmExitButton.onClick.AddListener(ConfirmQuit);
        optionsButton.onClick.AddListener(OpenOptions);
        optionsBackButton.onClick.AddListener(CloseOptions);

        firstSelectedButton = eventSystem.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    private void RequestQuit()
    {
        confirmationPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(cancelExitButtonObject, new BaseEventData(eventSystem));
    }

    private void CancelQuit()
    {
        confirmationPanel.SetActive(false);
        firstSelectedButton.SetSelectedGameObject(startButtonObject, new BaseEventData(eventSystem));
    }

    private void ConfirmQuit()
    {
        // Only quits actual game, not game running in editor
        Application.Quit();
    }

    private void OpenOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(optionsBackButtonObject, new BaseEventData(eventSystem));
    }

    private void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
        firstSelectedButton.SetSelectedGameObject(startButtonObject, new BaseEventData(eventSystem));
    }

}
