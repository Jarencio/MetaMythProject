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

    public void Here(int ES){
       enemyspawn = ES;
    }

    public void OnTriggerEnter(Collider other)
    {
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
         
         if(function=="Item1"){
 Debug.Log("1");
         } else if (function=="Item2"){
 Debug.Log("2");
         } else if (function=="Item3"){
 Debug.Log("3");
         } else if (function=="Item4"){
 Debug.Log("4");
         } else if (function=="Item5"){
 Debug.Log("5");
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
        if (spawnedItem != null && spawnItemOn != null)
        {
            Instantiate(spawnedItem, spawnItemOn[enemyspawn].position, Quaternion.identity);
            spawnedItem.SetActive(true);
        }
    }
}