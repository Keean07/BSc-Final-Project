using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetVolume()
    {
        audioMixer.SetFloat("Master", volumeSlider.value);
        Debug.Log("Set volume");
    }
}
