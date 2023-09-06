using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicAudio;
    [SerializeField] AudioSource clickAudio;
    [SerializeField] AudioSource hoverAudio;
    [SerializeField] AudioSource deathAudio;
    [SerializeField] AudioSource coinCollectAudio;
    [SerializeField] AudioSource progressAudio;

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

    public void CollectSound()
    {
        coinCollectAudio.Play();
    }

    public void DeathSound()
    {
        deathAudio.Play();
    }

    public void ProgressSound()
    {
        progressAudio.Play();
    }
}
