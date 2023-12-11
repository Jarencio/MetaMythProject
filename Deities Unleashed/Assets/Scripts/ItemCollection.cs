using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public static event Action OnCollected;
    public GameObject ItemPrefab;
    public GameObject spawnedItem;
    public GameObject[] enemyToDestroy;
    public Transform[] spawnItemOn;
    public CharacterLevelSystem CS;
    public string function;
    public Inventory inventory;
    public int enemyspawn;
    public Transform newItemParent; // Public field to hold the new parent
    public GameObject[] Enables;

    public void Here(int ES){
       enemyspawn = ES;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(inventory.s<10){
        if (other.CompareTag("Player"))
        {
            Debug.Log("COLLECTED");
            OnCollected?.Invoke();

            // Destroy the enemy GameObject
            if (enemyToDestroy[enemyspawn] != null)
            {
                Destroy(enemyToDestroy[enemyspawn]);
            }

            // Destroy the item GameObject
            Destroy(gameObject);

            // Spawn experience particles
         
         if(function=="HealthBoost"){
CS.currenthealth += 20;
CS.health += 20;
         } else if (function=="DefenseBoost"){
 CS.defense += 2;        
  } else if (function=="Item3"){
 Debug.Log("3");
         } else if (function=="Item4"){
 Debug.Log("4");
         } else if (function=="Item5"){
 Debug.Log("5");
         }
        int x = inventory.s;
        Debug.Log("x: " +x);
        Enables[x].SetActive(true);
        inventory.s++;
        }
        }
        inventory.EnableAnimator1();
    }

    /*public void RespawnItem()
    {
        // Deactivate the current item
        if (spawnedItem != null)
        {
            spawnedItem.SetActive(false);
        }

        // Respawn the item at a new position
        Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0.5f, UnityEngine.Random.Range(-5f, 5f));

        // Spawn a new item at the calculated position
        spawnedItem = Instantiate(ItemPrefab, respawnPosition, Quaternion.identity);
        spawnedItem.SetActive(true);

    }*/

    public void RespawnItem()
    {
        if (spawnedItem != null && newItemParent != null)
        {
            // Instantiate a new item at the specified position
            GameObject newItem = Instantiate(spawnedItem, spawnItemOn[enemyspawn].position, Quaternion.identity);

            // Set the parent of the new item to the specified parent reference
            newItem.transform.SetParent(newItemParent);

            // Set the clone (newly instantiated item) to active
            newItem.SetActive(true);

            Destroy(newItem, 20f);

        }
    }
}
