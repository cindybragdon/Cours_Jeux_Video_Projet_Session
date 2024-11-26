using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public Canvas canvasHint; // The canvas to show
    private CanvasGroup canvasGroup; // The CanvasGroup to control transparency and interaction
    public float fadeDuration = 2f; // Fade duration for the canvas
    public float timeBeforeFade = 1f; // Time before canvas starts fading
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