using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingImporter : MonoBehaviour
{
    [SerializeField] private VolumeController volumeController;
    [SerializeField] private BrightnessController brightnessController;

    //[SerializeField] private DontDestroyOnLoad dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        //dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        //if (dontDestroy.mustLoad)
        //{
        //    LoadGameSettings();
        //}
        if (PlayerPrefs.GetInt("Load") == 1)
        {
            LoadGameSettings();
        } else
        {
            PlayerPrefs.SetInt("Load", 1);
        }
    }

    private void LoadGameSettings()
    {
        brightnessController.LoadBrightness(PlayerPrefs.GetFloat("Brightness"));
        volumeController.LoadVolume(PlayerPrefs.GetFloat("Volume"));
        Debug.Log("Loading brightness: " + PlayerPrefs.GetFloat("Brightness") + " Volume: " + PlayerPrefs.GetFloat("Volume"));
        //brightnessController.LoadBrightness(dontDestroy.GetBrightness());
        //volumeController.LoadVolume(dontDestroy.GetVolume());
    }

    public void SaveGameSettings()
    {
        PlayerPrefs.SetFloat("Brightness", brightnessController.GetBrightness());
        PlayerPrefs.SetFloat("Volume", volumeController.GetVolume());

        //dontDestroy.SaveSettings(volumeController.GetVolume(), brightnessController.GetBrightness());
    }
}
