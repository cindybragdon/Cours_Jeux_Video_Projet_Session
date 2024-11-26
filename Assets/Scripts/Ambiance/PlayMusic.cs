using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;

    public List<AudioClip> listOfMusics; 
    private int comptorListMusic = 0;

    public float volume = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            audioSource.PlayOneShot(listOfMusics[comptorListMusic], volume);
            if(comptorListMusic >= listOfMusics.Count) {
                comptorListMusic = 0;
            } else {
                comptorListMusic += 1;
            }

        }
    }
}
