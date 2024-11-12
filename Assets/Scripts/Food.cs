using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public ProgressHunger progressHunger;
    private float currentHealth;
    private float maxHealth = 100f;

    void Start ()
    {
        currentHealth = maxHealth;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.CompareTag("Player"))
        {

            Debug.Log("Food Collected");
            currentHealth += 10f;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
            progressHunger.Val= currentHealth;// Appeler la mise à jour de la barre de santé

            Destroy(gameObject);


        }}
}
