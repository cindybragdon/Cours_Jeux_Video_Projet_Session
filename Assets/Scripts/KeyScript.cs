using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private static int keysCollected = 0;
    private static int totalKeys = 3;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.CompareTag("Player"))
        {
            keysCollected++;

            Debug.Log("Keys Collected: " + keysCollected);

            if (keysCollected >= totalKeys)
            {
                GameObject.Find("Door").GetComponent<ExitDoor>().CanOpen = true;
            }

            Destroy(gameObject);
        }
    }
}
