using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public ProgressEneergy progressEneergy;
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

            Debug.Log("Battery Collected");
            currentHealth += 10f;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
            progressEneergy.Val= currentHealth; 
            Destroy(gameObject);
        }}
}
