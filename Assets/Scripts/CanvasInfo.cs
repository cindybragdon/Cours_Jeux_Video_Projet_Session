using UnityEngine;

public class CanvasInfo : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float Duration = 5f;  
    private float time = 0f;    

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    void Update()
    {
        if (time >= Duration)
        {
            canvasGroup.alpha = 0f;  
            return;
        }

        time += Time.deltaTime;

        float alphaValue = 1 - (time / Duration);
        canvasGroup.alpha = alphaValue;
    }
}
