using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public float brightnessValue;
    public float volumeValue;

    public bool mustLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SaveSettings(float volume, float brightness)
    {
        Debug.Log("Saving volume: " + volume + " and brightness: " + brightness);
        brightnessValue = brightness;
        volumeValue = volume;
        mustLoad = true;
    }

    public float GetBrightness()
    {
        return brightnessValue;
    }

    public float GetVolume()
    {
        return volumeValue;
    }
}
