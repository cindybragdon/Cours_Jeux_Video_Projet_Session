using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public Rigidbody rb;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Assigner le Rigidbody du joueur s'il n'est pas déjà assigné
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Initialiser la direction du mouvement à zéro
        moveDirection = Vector3.zero;

        // Gérer l'input des flèches du clavier pour les directions avant, arrière, gauche, droite
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += transform.forward; // Avancer
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection -= transform.forward; // Reculer
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection -= transform.right; // Aller à gauche
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += transform.right; // Aller à droite
        }

        // Normaliser la direction du mouvement pour éviter des mouvements plus rapides en diagonale
        moveDirection = moveDirection.normalized;

        // Déplacer le joueur
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
