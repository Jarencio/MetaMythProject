using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public CharacterLevelSystem CS;
    public int Level;
    public float Health;
    public float MinDmg;
    public float MaxDmg;
    public float Defense;
    public int expgain;
    // Define the health of our target

    private int minLevel = 1;
    private int maxLevel = 25;



    void Start()
    {
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
            Health = 20f + (10f * Level);
            MinDmg = 7f + (3f * Level);
            MaxDmg = 12f + (5f * Level);
            Defense = 3f + (2f * Level);
        }
        else if (objectTag == "TikTik")
        {
            Health = 30f + (10f * Level);
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

        else if (objectTag == "Golemn")
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

        expgain = 2 + (2 * Level);

    }

    public void TakeDamage(float amount)
    {
        // Deduct health based on the amount of damage taken
        float a = amount - Defense;
      if (a < 0)
        {
            a = 0;
        }
        Health -= a;
        Debug.Log("Damage Taken: " + a);
        Debug.Log("Remaining Health: " + Health);
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the game object when health reaches zero
        CS.GainExperience(expgain);
        Destroy(gameObject);
        Debug.Log("Dead");
    }
}




