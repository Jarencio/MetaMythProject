using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Corrected import
using UnityEngine.UIElements;

public class EnemyTarget : MonoBehaviour
{
    public GameObject clearText;
    public float spawnOffsetDistance = 1.0f;
    public ItemCollection[] Item;
    public ExpParticleCollision expCollide;
    public GameObject healthprefabs;
    public GameObject bloodParticles;
    public Popup pop;
    private Animator anim;
    public AudioSource deathSound;
    public GameObject Pref;
    public CharacterLevelSystem CS;
    public GameObject burningParticlesPrefab;
    public BoxCollider boxCollider1;
    public int enemyspawn;


    public CircleCollider2D cicleCollider;

    public int Level;
    public float Health;
    public float MaxHealth;
    public float MinDmg;
    public float MaxDmg;
    public float Defense;
    public int expgain;
    // Define the health of our target

    private int minLevel = 1;
    private int maxLevel = 25;
    [SerializeField] FloatingHealth healthbar;


    void Start()
    {
    Levels();
    }

    public void Levels(){
                anim = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();

        Debug.Log("Health: " + Health);
        // Ensure CS is not null
        if (CS != null)
        {
            // Calculate the minimum value for the random level
            int min = Mathf.Max(minLevel, CS.currentLevel - 1);  // Minimum level is 1 or current level - 1, whichever is higher

            // Calculate the maximum value for the random level
            int max = Mathf.Min(CS.currentLevel + 1, maxLevel);  // Maximum level is current level + 1 or the maximum level, whichever is lower

            // Generate a random level within the updated range
            int MonsterLvl = Random.Range(min, max + 1);  // Adding 1 to max to make it inclusive

            // Assign the generated level to currentLevel
            Level = MonsterLvl;
            healthbar = GetComponentInChildren<FloatingHealth>();

            Stats();
        }
    }

    void Stats()
    {
        string objectTag = gameObject.tag;

        if (objectTag == "Tiyanak")
        {
            Health = 10f + (10f * Level);
            MinDmg = 5f + (3f * Level);
            MaxDmg = 10f + (5f * Level);
            Defense = 2f + (2f * Level);
        }
        else if (objectTag == "BalBal")
        {
            Health = 15f + (10f * Level);
            MinDmg = 7f + (3f * Level);
            MaxDmg = 12f + (5f * Level);
            Defense = 3f + (2f * Level);
        }
        else if (objectTag == "TikTik")
        {
            Health = 20f + (10f * Level);
            MinDmg = 10f + (3f * Level);
            MaxDmg = 15f + (5f * Level);
            Defense = 4f + (2f * Level);
        }

        else if (objectTag == "Phoenix")
        {
            if (Level < 9)
            {
                Level = 9;
            }
            Health = 30f + (10f * Level);
            MinDmg = 13f + (3f * Level);
            MaxDmg = 20f + (5f * Level);
            Defense = 2f + (2f * Level);
        }

        else if (objectTag == "Golem")
        {
            if (Level < 9)
            {
                Level = 9;
            }
            Health = 10f + (10f * Level);
            MinDmg = 9f + (3f * Level);
            MaxDmg = 10f + (5f * Level);
            Defense = 12f + (2f * Level);
        }

        else if (objectTag == "Wolf")
        {
            if (Level < 9)
            {
                Level = 9;
            }
            Health = 20f + (10f * Level);
            MinDmg = 5f + (3f * Level);
            MaxDmg = 20f + (5f * Level);
            Defense = -6f + (2f * Level);
        }

        else if (objectTag == "Cyclops")
        {
            if (Level < 17)
            {
                Level = 17;
            }
            Health = 20f + (10f * Level);
            MinDmg = 7f + (3f * Level);
            MaxDmg = 12f + (5f * Level);
            Defense = 4f + (2f * Level);
        }

        else if (objectTag == "ElectricGolem")
        {
            if (Level < 17)
            {
                Level = 17;
            }
            Health = 30f + (10f * Level);
            MinDmg = 9f + (3f * Level);
            MaxDmg = 5f + (5f * Level);
            Defense = 12f + (2f * Level);
        }

        else if (objectTag == "Eagle")
        {
            if (Level < 17)
            {
                Level = 17;
            }
            Health = 20f + (10f * Level);
            MinDmg = 7f + (3f * Level);
            MaxDmg = 12f + (5f * Level);
            Defense = 4f + (2f * Level);
        }

    else if(objectTag == "Mayari")
    {
                        Level = 8;
            Health = 500f;
            MinDmg = 70f;
            MaxDmg = 90f;
            Defense = 0f;
    }
    else if (objectTag == "Mapulon")
    {
        Level = 16;
        Health = 2200f;
        MinDmg = 90f;
        MaxDmg = 140f;
        Defense = 0f;
    }
    else if(objectTag == "Bathala"){
            Level = 25;
            Health = 5000f;
            MinDmg = 190f;
            MaxDmg = 140f;
            Defense = 0f;
        }

    else if (objectTag == "Spawner") 
    {
            Level = 5;
            Health = 500f;
            Defense = 0f;
            expgain = 0;


    }
    else if (objectTag == "NPC")
    {
        Level = 99;
        Health = 1f;
        Defense = 0f;
    }

        expgain = 5 + (2 * Level);
        MaxHealth = Health;

        if(objectTag == "Mayari"){

        expgain = 1000000;

        }
        if (objectTag == "Mapulon")
        {

            expgain = 1000000;

        }
        if (objectTag == "Bathala")
        {

            expgain = 1000000;

        }
        if (healthbar != null)
        {
            pop.Lvl(Level);
            healthbar.UpdateHealthBar(Health, MaxHealth);
            
        }



    }
    

    public void TakeDamage(float amount)
    {
        string objectTag = gameObject.tag;

        // Deduct health based on the amount of damage taken
        float a = amount - Defense;
        
        if (objectTag == "Mayari"){
            if (a > 1000)
            {
                a -= 1000;
            }
        }
        else if (objectTag == "Mapulon")
        {
            if (a > 1000)
            {
                a -= 1000;
            }
        }
        else if (objectTag == "Bathala")
        {
            if (a > 1000)
            {
                a -= 1000;
            }
        }
        else if (objectTag == "Spawner")
        {
            if (a > 1000)
            {
                a -= 1000;
            }
        }
        
    
        if (a < 0)
        {
            a = 0;
        }


        Health -= a;
        Debug.Log("Damage Taken: " + a);
        Debug.Log("Remaining Health: " + Health);

        if (Health <= 0)
        {
            deathSound.Play();
            anim.SetTrigger("death");
            Invoke("Die", 1.0f);//delay
        }

        // Instantiate blood particles at the enemy's position
        InstantiateBloodParticles();

        //Floating Damage
        DisplayFloatingDamage(a);
        healthbar.UpdateHealthBar(Health, MaxHealth);

    }

    void InstantiateBloodParticles()
    {
        // Instantiate blood particles at the enemy's position
        if (bloodParticles != null)
        {
            Instantiate(bloodParticles, transform.position, Quaternion.identity);

            Destroy(bloodParticles, 2.0f) ;
        }
    }



    void DisplayFloatingDamage(float damageAmount)
    {
        // Calculate a random position around the enemy within a specified range
        float xRange = Random.Range(-1.0f, 1.0f); // Adjust the range as needed
        float zRange = Random.Range(-1.0f, 1.0f); // Adjust the range as needed

        Vector3 randomOffset = new Vector3(xRange, 0.5f, zRange); // Adjust the '0.5f' value for vertical offset.

        Vector3 textPosition = transform.position + randomOffset + transform.forward * 2f; // Adjust the '2f' value for forward offset.

        // Instantiate the damage text in the calculated random position
        GameObject damageText = Instantiate(Pref, textPosition, Quaternion.identity);

        // Access the Popup component of the instantiated object and set the damage value
        Popup popup = damageText.GetComponent<Popup>();
        if (popup != null)
        {
            popup.Setup((int)damageAmount);
        }

        // Destroy the damage text after 2 seconds
        Destroy(damageText, 2.0f); // Adjust the time (2.0f) as needed.
    }

    public void Burn()
    {
        string objectTag = gameObject.tag;

        if (objectTag == "Phoenix")
        {
            
        }
        else
        {
            StartCoroutine(DecreaseHealthOverTime());
            Debug.Log("Burning Starts!");

            Vector3 spawnPosition = transform.position + transform.forward * spawnOffsetDistance;

            // Instantiate particles with the adjusted position
            Instantiate(burningParticlesPrefab, spawnPosition, Quaternion.identity);
        }
     }

        IEnumerator DecreaseHealthOverTime()
    {

        Debug.Log("NOW!");
        
        float totalTime = 20f; // Total duration in seconds
        float interval = 3f;   // Interval for health decrease in seconds

        while (totalTime > 0f)
        {
            yield return new WaitForSeconds(interval);

            // Decrease health by a random value between 0 and 5
            int damage = Random.Range(0, 3);
            Health -= damage;
            DisplayFloatingDamage(damage);
            healthbar.UpdateHealthBar(Health, MaxHealth);
            totalTime -= interval;
        }

        // Health decrease is complete
        Debug.Log("Health decrease complete!");

    }



    void Die()
    {
        string objectTag = gameObject.tag;

        // Deactivate the BoxCollider
        if (boxCollider1 != null) boxCollider1.enabled = false;

        Destroy(healthprefabs);
        // Destroy the game object when health reaches zero
        Destroy(healthprefabs);
        CS.GainExperience(expgain);
        
        Destroy(gameObject);

        // Deactivate the BoxCollider
 
        if (cicleCollider != null) cicleCollider.enabled = false;

            int randoms = Random.Range(0,6);
        if (randoms==2)
        {
            int item = Random.Range(0, Item.Length);
            Item[item].Here(enemyspawn);   
            Item[item].RespawnItem();
        }
        Debug.Log("Dead");

        expCollide.SpawnExpParticles();

        
        if (objectTag == "Mayari")
        {
            clearText.SetActive(true);
        }
        else if(objectTag == "Mapulon")
        {
            clearText.SetActive(true);
        }
        else if (objectTag == "Bathala")
        {
            clearText.SetActive(true);
        }


    }
}