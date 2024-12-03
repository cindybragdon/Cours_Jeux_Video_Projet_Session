using NUnit.Framework;
using UnityEngine;
 
public class PlayerHealthTests
{
    private PlayerHealth playerHealthScript;
 
    [SetUp]
    public void Setup()
    {
        // GameObject pour le script PlayerHealth
        GameObject testObject = new GameObject();
 
        playerHealthScript = testObject.AddComponent<PlayerHealth>();
 
        playerHealthScript.playerHealth = 100;
       
    }
 
    [Test]
    public void PlayerTakingDamageTest()
    {
 
        playerHealthScript.PlayerTakingDamage(10f);
 
       
        Assert.AreEqual(90f, playerHealthScript.playerHealth, "La sant� du joueur n'a pas �t� reduite correctement");
    }
    [Test]
    public void PlayerNotTakingDamageNotOverLimitTest()
    {
       
        playerHealthScript.playerHealth = 95f;
       
 
       
        playerHealthScript.PlayerNotTakingDamage(10f);
 
       
        Assert.AreEqual(100f, playerHealthScript.playerHealth, "La sant� du joueur d�passe la limite maximum de 100");
    }
}