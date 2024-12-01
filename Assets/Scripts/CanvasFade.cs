// Ce script permet de faire apparaître et disparaître un Canvas en modifiant son opacité. 
// Il attend un certain délai avant de commencer l'animation de fondu et gère les transitions entre l'état visible et invisible.
using UnityEngine;

public class CanvasFader : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 2f;
    public float timeBeforeFade = 1f;
    private float timePassed = 0f;

    private bool isFadingIn = false;
    private bool isFadingOut = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (!isFadingOut && canvasGroup.alpha == 1f)
            {
                timePassed += Time.deltaTime;
                if (timePassed >= timeBeforeFade)
                {
                    isFadingOut = true;
                }
            }

            if (isFadingOut)
            {
                canvasGroup.alpha -= (Time.deltaTime / fadeDuration);
                canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);

                if (canvasGroup.alpha == 0f)
                {
                    canvasGroup.interactable = false;
                    canvasGroup.blocksRaycasts = false;
                    isFadingOut = false;
                }
            }
        }
        else
        {
            if (!isFadingIn && canvasGroup.alpha == 0f)
            {
                timePassed += Time.deltaTime;
                if (timePassed >= timeBeforeFade)
                {
                    isFadingIn = true;
                }
            }

            if (isFadingIn)
            {
                canvasGroup.alpha += (Time.deltaTime / fadeDuration);
                canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha);

                if (canvasGroup.alpha == 1f)
                {
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                    isFadingIn = false;
                }
            }
        }
    }
}
