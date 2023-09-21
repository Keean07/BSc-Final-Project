using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingImporter : MonoBehaviour
{
    [SerializeField] private VolumeController volumeController;
    [SerializeField] private BrightnessController brightnessController;
    [SerializeField] private DontDestroyOnLoad dontDestroy;

    // Start is called before the first frame update
    void Start()
    {
        dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if (dontDestroy.mustLoad)
        {
            LoadGameSettings();
        }
    }

    private void LoadGameSettings()
    {
        brightnessController.LoadBrightness(dontDestroy.GetBrightness());
        volumeController.LoadVolume(dontDestroy.GetVolume());
    }

    public void SaveGameSettings()
    {
        dontDestroy.SaveSettings(volumeController.GetVolume(), brightnessController.GetBrightness());
    }
}
