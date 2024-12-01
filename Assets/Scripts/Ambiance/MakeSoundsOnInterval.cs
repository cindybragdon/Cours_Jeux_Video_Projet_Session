// Ce script permet de jouer des sons à des intervalles aléatoires entre un minimum et un maximum de secondes. 
// Les sons sont choisis de manière aléatoire à partir d'une liste et sont joués via un AudioSource.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundsOnInterval : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> listOfSounds;
    public int maxNumberSecondsToPlay = 20;
    public int minNumberSecondsToPlay = 7;
    private float elapsedTime = 0f;
    private float nextMomentPlaySound;
    public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
         nextMomentPlaySound = Random.Range(minNumberSecondsToPlay, maxNumberSecondsToPlay);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= nextMomentPlaySound) {
            elapsedTime = 0;
            AudioClip soundToPlay = listOfSounds[Random.Range(0,listOfSounds.Count)];
            audioSource.PlayOneShot(soundToPlay, volume);
            nextMomentPlaySound = Random.Range(minNumberSecondsToPlay, maxNumberSecondsToPlay);
        }
    } 
}
