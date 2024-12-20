// Ce script définit une classe "Item" qui représente un objet avec un nom et une quantité.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int count;
 
    public Item(string itemName, int itemCount)
    {
        name = itemName;
        count = itemCount;
    }
}
