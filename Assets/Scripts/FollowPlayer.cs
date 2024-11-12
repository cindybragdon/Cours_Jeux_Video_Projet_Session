using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Référence à l'objet du joueur
    public Vector3 offset;    // Décalage de la caméra par rapport au joueur

    void Start()
    {
        // Si le décalage n'est pas défini, le calculer par rapport à la position actuelle de la caméra
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Positionner la caméra derrière le joueur en tenant compte de la rotation du joueur
        Vector3 desiredPosition = player.position + player.rotation * offset;
        transform.position = desiredPosition;

        // Faire en sorte que la caméra regarde toujours le joueur (ou un point devant le joueur)
        transform.LookAt(player.position + player.forward * 10f);
    }
}
