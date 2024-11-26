using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerRange : MonoBehaviour
{
    GameObject player;
    public float seenMaxRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Initialiser les variables d'objets
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Si la créature est dans une certaine reach du joueur,
        //Faire en sorte que la créature la regarde
        if (Vector3.Distance(transform.position, player.transform.position) < seenMaxRange) {

            //Permet à la créature de regarder le joueur
            transform.LookAt(player.transform);
            print("je regarde le joueur");
        }
    }
}
