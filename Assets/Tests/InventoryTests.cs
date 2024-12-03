using NUnit.Framework;
using UnityEngine;
 
 
public class InventoryTests
{
    private Inventory inventory;
    private GameObject testItem;
 
    [SetUp]
    public void SetUp()
    {
        // Cr�e un objet de test avec un composant Inventory
        inventory = new GameObject().AddComponent<Inventory>();
        testItem = new GameObject("TestItem");
    }
 
    [Test]
    public void ContainsItemTest()
    {
       
        inventory.AddItem(testItem);
       
        Assert.IsTrue(inventory.ContainsItem(testItem), "L'�l�ment devrait �tre dans l'inventaire.");
    }
 
    [Test]
    public void RemoveItemTest()
    {
 
        inventory.AddItem(testItem);
       
 
        inventory.RemoveItem(testItem);
 
        Assert.AreEqual(0, inventory.items.Count, "L'�l�ment n'a pas �t� supprim� correctement.");
        Assert.IsFalse(inventory.items.Contains(testItem), "L'�l�ment est toujours pr�sent dans l'inventaire.");
    }
 
    [Test]
    public void GetItemTest()
    {
       
        inventory.AddItem(testItem);
        int itemIndex = 0;
 
       
        GameObject retrievedItem = inventory.getItem(itemIndex);
 
       
        Assert.AreEqual(testItem, retrievedItem, "L'�l�ment r�cup�r� n'est pas celui attendu.");
    }
 
 
}