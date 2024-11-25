using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerRange : MonoBehaviour
{

    Animator animator;
    AudioSource audioSource;
    GameObject player;
    public List<AudioClip> listStepSounds;


    public float maxFollowRange = 20f;
    public float minFollowRange = 2f;
    public float speed = 1.5f;
    private float elapsedTime = 0f;
    private float nextMomentToPlayStepSound = 1f;
    public float volume = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        //Initialiser les variables d'objets
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //Active le déplacement si le joueur est à une distance appropriée.
        //Il y a aussi un minimum pour ne pas que la créature monte
        //Sur le joueur
        if ((Vector3.Distance(transform.position, player.transform.position) < maxFollowRange)
           && (Vector3.Distance(transform.position, player.transform.position) > minFollowRange))
        {

            //Permet à la créature de se déplacer vers le joueur
            transform.position += transform.forward * speed * Time.deltaTime;
            //Activer l'animation de déplacement
            animator.SetBool("moving", true);

            //Fait des bruits de pas à des intervales réguliers
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= nextMomentToPlayStepSound) {
                elapsedTime = 0;
                AudioClip soundToPlay = listStepSounds[Random.Range(0,listStepSounds.Count)];
                audioSource.PlayOneShot(soundToPlay, volume);
                Debug.Log("played the sound" + soundToPlay);
            }
        } else {
            //Désactiver l'animation de déplacement
            animator.SetBool("moving", false);
        }
    }
}
