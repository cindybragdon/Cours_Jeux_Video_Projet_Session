using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiants : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;
    public List<AudioClip> listAmbiantSounds;

    public int maxNumberSecondsToWait = 20;
    public int minNumberSecondsToWait = 7;
    private float elapsedTime = 0f;
    private float nextMomentToPlaySound;
    public float volume = 0.5f;

    //Note : Il fait que vous allez mettre des sons dans 
    //Le moteur unity dans la listAmbiantSounds pour que ça marche

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        nextMomentToPlaySound = Random.Range(minNumberSecondsToWait, maxNumberSecondsToWait);
    }

    // Update is called once per frame
    void Update()
    {
        //Fait jouer un son après un moment donné aléatoirement.
        //augmente la variable elapsedTime. Elle contient le nombre de temps total
        //Qu'on a attendu depuis la dernière itération.
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= nextMomentToPlaySound) {
            elapsedTime = 0;

            //Choisi un sons aléatoire de la liste de sons et le fait jouer
            AudioClip soundToPlay = listAmbiantSounds[Random.Range(0,listAmbiantSounds.Count)];
            audioSource.PlayOneShot(soundToPlay, volume);
            //Debug.Log("played the sound" + soundToPlay);

            //Choisi aléatoirement le prochain moment pour le prochain son avec le nombre
            //minimum de secondes et le nombre maximal de secondes à attendre
            nextMomentToPlaySound = Random.Range(minNumberSecondsToWait, maxNumberSecondsToWait);

        }

    } 
}
