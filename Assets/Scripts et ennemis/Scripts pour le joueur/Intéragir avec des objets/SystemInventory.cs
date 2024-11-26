
using UnityEngine;
using System.Collections.Generic;

public class GameObjectInventory : MonoBehaviour
{
    public static GameObjectInventory Instance;
    public int maxSlots = 4;
    
    private Dictionary<GameObject, int> inventory = new Dictionary<GameObject, int>();
    private List<GameObject> itemList = new List<GameObject>(); // Keep track of items in order
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    // Add item to inventory
    public bool AddItem(GameObject item)
    {
        if (inventory.Count < maxSlots)
        {
            if (inventory.ContainsKey(item))
            {
                Debug.Log("Objet deja la ");
            }
            else
            {
                inventory.Add(item, 1);
                itemList.Add(item);
            }
            Debug.Log($"Added {item.name} to inventory");
            return true;
        }
        
        Debug.Log("Inventory full!");
        return false;
    }
    
    
    public GameObject RemoveItem(string itemName)
    {
        foreach (GameObject item in itemList)
        {
            if (item.name == itemName && inventory[item] > 0)
            {
                inventory[item]--;
                
                if (inventory[item] <= 0)
                {
                    inventory.Remove(item);
                    itemList.Remove(item);
                }
                
                return item;
            }
        }
        return null;
    }
    
    
    public bool UseItem(string itemName, Vector3 spawnPosition)
    {
        GameObject itemToUse = RemoveItem(itemName);
        
        if (itemToUse != null)
        {
            Instantiate(itemToUse, spawnPosition, Quaternion.identity);
            Debug.Log($"Used/Spawned {itemName}");
            return true;
        }
        
        Debug.Log($"No {itemName} in inventory!");
        return false;
    }
    
 
    public bool HasItem(string itemName)
    {
        foreach (GameObject item in itemList)
        {
            if (item.name == itemName && inventory[item] > 0)
                return true;
        }
        return false;
    }
    
   
    public int GetItemCount(string itemName)
    {
        foreach (GameObject item in itemList)
        {
            if (item.name == itemName)
                return inventory[item];
        }
        return 0;
    }
    

}