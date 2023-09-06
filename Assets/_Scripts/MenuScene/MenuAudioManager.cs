using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource clickAudio;
    [SerializeField] AudioSource hoverAudio;

    // Start is called before the first frame update
    void Start()
    {

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
