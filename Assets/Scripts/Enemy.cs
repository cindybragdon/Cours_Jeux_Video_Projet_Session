using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ProgressBar1 progressBar1;
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

            Debug.Log("Health -10 !");
            currentHealth -= 10f;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
            progressBar1.Val= currentHealth;// Appeler la mise à jour de la barre de santé


        }}
}