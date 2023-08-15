using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicAudio;
    [SerializeField] AudioSource clickAudio;
    [SerializeField] AudioSource hoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        musicAudio.Play();
    }

    public void ClickSound()
    {
        clickAudio.Play();
    }

    public void HoverSound()
    {
        hoverAudio.Play();
    }
}
