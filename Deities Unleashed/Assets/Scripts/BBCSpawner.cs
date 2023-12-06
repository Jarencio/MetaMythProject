using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBCSpawner : MonoBehaviour
{
    public CharacterLevelSystem CS;
    [SerializeField] float life = 3;
    [SerializeField] int minDamage; // Minimum damage
    [SerializeField] int maxDamage; // Maximum damage

    // Define the tags that the arrow should compare against
    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle", "Mayari" };

    private bool damageApplied = false; // Flag to track if damage has already been applied
    private Collider myCollider;    
    void Awake()
    {
        // Find the "Player" GameObject and get the attached "CharacterLevelSystem" script
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            CS = player.GetComponent<CharacterLevelSystem>();
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the GameObject is named 'Player' and has the 'CharacterLevelSystem' script attached.");
        }

        // Get the collider component
        myCollider = GetComponent<Collider>();
        if (myCollider == null)
        {
            Debug.LogError("Collider component not found on GameObject.");
        }

        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        minDamage = 10 + (5 * CS.currentLevel);
        maxDamage = 20 + (10 * CS.currentLevel);
        Debug.Log("" + minDamage + " & " + maxDamage);

        // Check if damage has already been applied
        if (damageApplied)
            return;

        // Generate a random damage value between minDamage and maxDamage
        int damage = Random.Range(minDamage, maxDamage + 1); // +1 to include the maximum value

        // Generate a random number between 1 and 10 for critical hit
        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical: " + criticalRoll);

        // Check for a critical hit (e.g., if the roll is 2, add 1000 damage)
        if (criticalRoll == 2)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        foreach (ContactPoint contact in collision.contacts)
        {
            // Iterate over all contact points and apply damage to each enemy
            foreach (string targetTag in targetTags)
            {
                if (contact.otherCollider.CompareTag(targetTag))
                {
                    EnemyTarget enemyDamageReceiver = contact.otherCollider.GetComponent<EnemyTarget>();
                    Rigidbody enemyRigidbody = contact.otherCollider.GetComponent<Rigidbody>();

                    if (enemyDamageReceiver != null)
                    {
                        int s = 0;
                        enemyDamageReceiver.TakeDamage(damage);
                        Debug.Log("Applied Damage: " + damage);

                        // Freeze the position of the collided object
                        if (enemyRigidbody != null)
                        {
                            enemyRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                            s = 1;
                        }
                        if (s == 1)
                        {
                            enemyRigidbody.constraints = RigidbodyConstraints.None;
                            s = 0;
                        }

                        damageApplied = true; // Set the flag to true to indicate damage has been applied
                    }

                    // Optionally, you can destroy the projectile after damaging each enemy
                    // Destroy(gameObject, life);

                    // No need to return; continue checking other enemies
                }
            }
        }
        myCollider.isTrigger = true;


        // If no matching tag is found, simply destroy the arrow
        Destroy(gameObject, life);
    }

    // Use OnTriggerEnter for detecting when enemies enter the collider
    void OnTriggerEnter(Collider other)
    {
        if (damageApplied) // Skip if damage has already been applied
            return;
        // Reset the damageApplied flag for a new collision
        damageApplied = false;
        // Generate a random damage value between minDamage and maxDamage
        int damage = Random.Range(minDamage, maxDamage + 1); // +1 to include the maximum value

        // Generate a random number between 1 and 10 for critical hit
        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical: " + criticalRoll);

        // Check for a critical hit (e.g., if the roll is 2, add 1000 damage)
        if (criticalRoll == 2)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        foreach (string targetTag in targetTags)
        {
            if (other.CompareTag(targetTag))
            {
                EnemyTarget enemyDamageReceiver = other.GetComponent<EnemyTarget>();
                Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();

                if (enemyDamageReceiver != null)
                {
                    int s = 0;
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);

                    // Freeze the position of the collided object
                    if (enemyRigidbody != null)
                    {
                        enemyRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                        s = 1;
                    }
                    if (s == 1)
                    {
                        enemyRigidbody.constraints = RigidbodyConstraints.None;
                        s = 0;
                    }

                    damageApplied = true; // Set the flag to true to indicate damage has been applied
                }

                // Optionally, you can destroy the projectile after damaging each enemy
                // Destroy(gameObject, life);

                // No need to return; continue checking other enemies
            }
        }
    }
}
