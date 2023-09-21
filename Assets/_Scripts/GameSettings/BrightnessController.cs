using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessController : MonoBehaviour
{
    public Slider brightnessSlider;

    [SerializeField] GameObject brightnessOverlay;

    private Color currentColor;

    private void Start()
    {
        brightnessSlider.value = 1;
    }

    // This method is called when the slider value changes
    public void SetBrightness()
    {
        currentColor = brightnessOverlay.GetComponent<Image>().color;
        currentColor.a = 1 - brightnessSlider.value;
        brightnessOverlay.GetComponent<Image>().color = currentColor;
    }
}
