// Ce script joue de la musique à partir d'une liste de clips audio, en les enchaînant lorsque le clip actuel se termine.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSource;  // Source audio pour jouer la musique
    public List<AudioClip> listOfMusics;  // Liste des clips audio
    private int comptorListMusic = 0;  // Compteur pour parcourir la liste
    public float volume = 0.5f;  // Volume de la musique

    void Start()
    {
        
    }

    void Update()
    {
        if(!audioSource.isPlaying)  // Si la musique ne joue pas
        {
            audioSource.PlayOneShot(listOfMusics[comptorListMusic], volume);  // Joue le clip courant
            if(comptorListMusic >= listOfMusics.Count)  // Si on a atteint la fin de la liste
            {
                comptorListMusic = 0;  // Recommence au début de la liste
            }
            else
            {
                comptorListMusic += 1;  // Passe au clip suivant
            }
        }
    }
}
