using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{

    Animator animator;
    AudioSource audioSource;
    GameObject player;
    public List<AudioClip> listAttackSounds;


    public int maxAttackRange = 2;
    public int minAttackRange = 0;
    private float elapsedTime = 0f;
    public float nextMomentToPlaySound = 3f;
    public float volume = 0.5f;




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
        //Vérifie si la cible (le joueur) est entre la range minimale et maximale pour attaquer
        //Le joueur.
        if ((Vector3.Distance(transform.position, player.transform.position) < maxAttackRange)
           && (Vector3.Distance(transform.position, player.transform.position) > minAttackRange))
        {
            //Activer l'animation attaquer
            animator.SetBool("attacking", true);

            //Faire jouer un son aléatoire d'attaque à chaque certain nombre de secondes
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= nextMomentToPlaySound) {
                elapsedTime = 0;
                audioSource.PlayOneShot(listAttackSounds[Random.Range(0,listAttackSounds.Count)], volume);
            }


        } else {
            //Si le joueur est trop loin ou hors de portée, arrêter l'animation d'attaque
            animator.SetBool("attacking", false);

        }
    }
}
