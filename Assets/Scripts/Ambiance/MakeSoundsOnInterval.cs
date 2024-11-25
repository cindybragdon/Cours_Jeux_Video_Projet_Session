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
            //Debug.Log("played the sound" + soundToPlay);
        }

    } 
    
}
