// Ce script gère la santé d'un joueur dans un jeu Unity. Il ajuste la santé du joueur en fonction des collisions avec des zones spécifiques,
// telles que la "DamageZone" (réduit la santé) et la "SafeZone" (augmente la santé). La transparence de l'image de la santé est mise à jour 
// pour refléter la quantité de vie restante du joueur.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;  
    public UnityEngine.UI.Image healthImpact;  

    void Start()
    {
        playerHealth = 100f;
        Debug.Log(playerHealth);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "DamageZone")
        {
            PlayerTakingDamage(10f);
        }

        if (other.gameObject.name == "SafeZone")
        {
            PlayerNotTakingDamage(10f);
        }
    }

    void HealthDamageImpact()
    {
        float transparency = 1f - (playerHealth / 100f);  
        Color imageColor = Color.white;
        imageColor.a = transparency;  
        healthImpact.color = imageColor; 
    }

    public void PlayerTakingDamage(float damage)
    {
        if (playerHealth > 0)
        {
            playerHealth -= damage;  
            playerHealth = Mathf.Clamp(playerHealth, 0f, 100f);  
            Debug.Log("Player is taking damage, current health: " + playerHealth);
        }
    }

    public void PlayerNotTakingDamage(float health)
    {
        if (playerHealth < 100)
        {
            playerHealth += health; 
            playerHealth = Mathf.Clamp(playerHealth, 0f, 100f);  
            Debug.Log("Player is not taking damage, current health: " + playerHealth);
        }
    }

    void Update()
    {
        HealthDamageImpact();  
    }
}
