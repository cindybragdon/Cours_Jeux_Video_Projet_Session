using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool CanOpen = false; // Control whether the door can open
    public Transform player;        // Référence au joueur
    public const float activationDistance = 3.0f;  // Distance d'activation de l'ennemi
    private Animator animator;      // Référence à l'Animator
    void Start()
    {
        // Si le joueur n'est pas assigné manuellement dans l'inspecteur, trouvez-le automatiquement
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Récupérer le composant Animator
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;  // Désactiver l'Animator au début
        }
    }

    private void Update()
    {
        if (player != null && animator != null)
        {
            // Calculer la distance entre l'ennemi et le joueur
            float distance = Vector3.Distance(player.position, transform.position);

          if (distance <= activationDistance)
            {
                CanOpen = true;


                if (!animator.enabled)
                {
                    animator.enabled = true;
                }
            }

        }
    }
}
