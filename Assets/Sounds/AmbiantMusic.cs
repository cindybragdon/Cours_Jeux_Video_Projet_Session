// When the audio component has stopped playing, play otherClip
using UnityEngine;
using System.Collections;

public class AmbiantMusic : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = otherClip;
            audioSource.Play();
        }
    }
}