using JetBrains.Annotations; // Permet l'utilisation d'annotations pour une meilleure analyse statique.
using UnityEngine; // Bibliothèque principale pour le développement sous Unity.
using UnityEngine.SceneManagement; // Nécessaire pour gérer les scènes dans Unity.

public class changeLevel : MonoBehaviour
{
    // Indique si un changement de niveau est en cours.
    public bool isLevelChanging = false;

    // Temps écoulé depuis le début du changement de niveau.
    private float elapsedTime = 0f;

    // Temps d'attente avant de changer de niveau.
    public float timeToWait = 5f;

    // Méthode appelée à chaque frame.
    void Update()
    {
        // Si un changement de niveau est en cours.
        if (isLevelChanging)
        {
            // Logique pour gérer le changement de niveau à ajouter ici.
        }
    }
}
