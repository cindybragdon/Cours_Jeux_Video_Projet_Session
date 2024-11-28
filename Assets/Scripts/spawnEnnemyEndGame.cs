using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnEnnemyEndGame : MonoBehaviour
{
    private bool isEnnemySpawned = false;

    private float elapsedTime = 0f;

    public int numberSecondsToEndGame = 300;

    private Vector3 ennemySpawnPosition;

    private float currentHealth;
    private float maxHealth = 100f;

    public GameObject player; 
    public float attackRange = 2f; 
    public float attackCooldown = 1f; 
    private float timeSinceLastAttack = 0f; 


    void Start()
    {
        ennemySpawnPosition = new Vector3(0f, 0f, 0f); 
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!isEnnemySpawned)
        {
             //À mettre sur le joueur
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= numberSecondsToEndGame)
            {
                Object ennemyPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Warzombie F Pedroso.prefab", typeof(GameObject));
                GameObject clone = Instantiate(ennemyPrefab, ennemySpawnPosition, transform.rotation) as GameObject;
                clone.transform.position = ennemySpawnPosition;
                clone.GetComponent<AI>().player = transform;
                clone.transform.localScale *= 2f;
                isEnnemySpawned = true;
                
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }

        if (isEnnemySpawned && player != null)
        {
        

            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                timeSinceLastAttack += Time.deltaTime;

                if (timeSinceLastAttack >= attackCooldown)
                {
                    AttackPlayer();
                    timeSinceLastAttack = 0f; 
                }
            }
        }
    }



    void AttackPlayer()
    {

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.PlayerTakingDamage(10);

            if (playerHealth.playerHealth <= 0f)
            {
            SceneManager.LoadScene("CanvasGameOver");
        }

        }
    }
}
