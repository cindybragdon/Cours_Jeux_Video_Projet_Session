// Ce script gère un objet "PickableItem" qui peut être activé ou désactivé. Lorsqu'il est désactivé, un canevas avec un indice visuel est activé. Le script gère aussi l'affichage et l'interaction du canevas.

using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public Canvas canvasHint; // Le canevas à afficher
    private CanvasGroup canvasGroup; // Le CanvasGroup pour contrôler la transparence et l'interaction
    public float fadeDuration = 2f; // Durée de disparition du canevas
    public float timeBeforeFade = 1f; // Temps avant que le canevas commence à disparaître
    private float timePassed = 0f;


    public float Duration = 2f;  
    private float time = 0f;    

    void Start()
    {
        if (canvasHint != null)
        {
            canvasGroup = canvasHint.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = canvasHint.gameObject.AddComponent<CanvasGroup>();
            }

            canvasHint.gameObject.SetActive(false);
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            Debug.LogError("CanvasHint is not assigned in the PickableItem script.");
        }
    }

    public void DeactivateItem()
    {
        gameObject.SetActive(false); 
        ActivateCanvas();
        
    }

    public void ActivateCanvas()
    {
        if (canvasHint != null)
        {
            canvasHint.gameObject.SetActive(true);  
            canvasGroup.alpha = 1f;                
            canvasGroup.interactable = true;  
            canvasGroup.blocksRaycasts = true;     
                 
        }
    }

  


    void OnDisable()
    {
        Debug.Log("Item deactivated. Showing canvas.");
        ActivateCanvas();
    }
}
