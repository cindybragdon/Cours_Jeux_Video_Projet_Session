using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    private int comptorNumberRemoveHealth = 0;

    public float targetHealth;

    // Fonction pour initialiser la barre de santé à la valeur maximale
    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    // Utilise une Coroutine pour mettre à jour progressivement la barre de santé
    public void SetHealth(float health)
    {
        comptorNumberRemoveHealth += 1;
        Debug.Log("compteur début" + comptorNumberRemoveHealth);
        Debug.Log("target helath : " + health);
        targetHealth = health;
        if(comptorNumberRemoveHealth == 1) {
            StartCoroutine(SmoothHealthTransition());
        } 

    }

    // Coroutine pour animer la transition de la barre de santé
    private IEnumerator SmoothHealthTransition()
    {
        
        while (Mathf.Abs(healthSlider.value - targetHealth) > 0.01f)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, targetHealth , Time.deltaTime * 5);
            yield return null; // Attendre le frame suivant avant de continuer la boucle
        }
        healthSlider.value = targetHealth;
        comptorNumberRemoveHealth = 0;
        Debug.Log(comptorNumberRemoveHealth);
        Canvas.ForceUpdateCanvases(); // Assurez-vous que le Canvas est à jour
    }
}



