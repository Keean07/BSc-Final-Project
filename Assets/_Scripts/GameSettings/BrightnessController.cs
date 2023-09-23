using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BrightnessController : MonoBehaviour
{
    public Slider brightnessSlider;

    [SerializeField] Image brightnessOverlay;

    private Color currentColor;

    private void OnAwake()
    {
        //brightnessSlider.value = 1;
    }

    // This method is called when the slider value changes
    public void SetBrightness()
    {
        currentColor = brightnessOverlay.GetComponent<Image>().color;
        currentColor.a = 1 - brightnessSlider.value;
        brightnessOverlay.GetComponent<Image>().color = currentColor;

    }

    public float GetBrightness()
    {
        return brightnessSlider.value;
    }

    public void LoadBrightness(float brightness)
    {
        brightnessSlider.value = brightness;
        SetBrightness();
    }
}
