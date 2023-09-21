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
    
    [SerializeField] private GameObject confirmationPanel;
    [SerializeField] private GameObject cancelExitButtonObject;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject optionsBackButtonObject;

    [SerializeField] private MenuAudioManager audioManager;
    [SerializeField] private VolumeController volumeController;
    [SerializeField] private BrightnessController brightnessController;
    [SerializeField] private DontDestroyOnLoad saveObject;

    private EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current.GetComponent<EventSystem>();
        saveObject.SaveSettings(volumeController.GetVolume(), brightnessController.GetBrightness());
    }

    public void LoadGame()
    {
        saveObject.SaveSettings(volumeController.GetVolume(), brightnessController.GetBrightness());
        SceneManager.LoadScene(1);
    }

    public void RequestQuit()
    {
        mainPanel.SetActive(false);
        confirmationPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(cancelExitButtonObject, new BaseEventData(eventSystem));
    }

    public void CancelQuit()
    {
        mainPanel.SetActive(true);
        confirmationPanel.SetActive(false);
        eventSystem.SetSelectedGameObject(startButtonObject, new BaseEventData(eventSystem));
    }

    public void ConfirmQuit()
    {
        // Only quits actual game, not game running in editor
        Application.Quit();
    }

    public void OpenOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(optionsBackButtonObject, new BaseEventData(eventSystem));
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(startButtonObject, new BaseEventData(eventSystem));
    }
    public void SelectNewButton(GameObject button)
    {
        if (button != eventSystem.currentSelectedGameObject)
        {
            eventSystem.SetSelectedGameObject(button, new BaseEventData(eventSystem));
            audioManager.HoverSound();
        }
    }

    public void DeselectButton()
    {
        eventSystem.SetSelectedGameObject(null);
    }
}
