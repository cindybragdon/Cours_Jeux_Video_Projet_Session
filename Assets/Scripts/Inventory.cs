using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log(item.name + " has been added to the inventory.");
    }

    public void RemoveItem(GameObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.name + " has been removed from the inventory.");
        }
    }

    public bool ContainsItem(GameObject item)
    {
        return items.Contains(item);
    }

    public GameObject getItem(int item){
        return items[item];        
    }
    public void DisplayInventory()
    {
        if (items.Count > 0)
        {
            Debug.Log("Inventory:");
            foreach (GameObject item in items)
            {
                Debug.Log(item.name);
            }
        }
        else
        {
            Debug.Log("Inventory is empty.");
        }
    }
}
