using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    public void SetVolume()
    {
        audioMixer.SetFloat("Master", volumeSlider.value);
    }

    public float GetVolume()
    {
        return volumeSlider.value;
    }

    public void LoadVolume(float volume)
    {
        Debug.Log("Loading volume: " + volume);
        volumeSlider.value = volume;
        SetVolume();
    }

}
