using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public float playerHealth;
    public UnityEngine.UI.Image healthImpact;



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
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
        float transparency = 1f - (playerHealth/100f);
        Color imageColor = Color.white;
        imageColor.a = transparency;
        healthImpact.color = imageColor;
    }

    void PlayerTakingDamage(float damage)
    {
        if(playerHealth > 0)
        {
            playerHealth -= damage;
            Debug.Log("Player is taking damage");
        }
    }

    void PlayerNotTakingDamage(float health)
    {
        if(playerHealth < 100)
        {
            playerHealth -= health;
            Debug.Log("Player is not taking damage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        HealthDamageImpact(); 
    }
}
