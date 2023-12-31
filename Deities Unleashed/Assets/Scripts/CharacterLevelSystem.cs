using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CharacterLevelSystem : MonoBehaviour
{
    public Button artificialBtn; //temporary
    public GameObject tempBoss;

   public int expboost = 0;
    public float regenerationAmount = 5;
    public float regenerationTimer = 10f;
    public float regenerationCooldown = 10f;


    public GameObject deadScreen;
    public Player P;
    public int currentLevel = 1;
    public int currentExp = 0;
    public int expToNextLevel = 20;
    // Player stats
    public float health = 200;
    public float currenthealth = 200;
    public float defense = 4;
    public FloatingHealth LvlBar;
    public FloatingHealth HealthBar;
    public Popup pops;



    // Function to gain experience points
    public void GainExperience(int expAmount)
    {
        if (currentLevel < 25)
        {
            expAmount+= expboost;
            currentExp += expAmount;
            Debug.Log("Gained " + expAmount + " experience points. Total experience: " + currentExp);
            LvlBar.UpdateHealthBar(currentExp, expToNextLevel);
            // Check if it's time to level up
            if (currentExp >= expToNextLevel)
            {
                LevelUp();
            }
        }
        else
        {
            Debug.Log("You've reached the maximum level (25) and can no longer gain experience.");
        }


    }

    // Function to level up
    private void LevelUp()
    {
        currentLevel++;
        currentExp = 0;
        LvlBar.UpdateHealthBar(currentExp, expToNextLevel);
        //Update the needed exp to move in next level!
        if (currentLevel == 8 || currentLevel == 16 || currentLevel == 25)
        {
            expToNextLevel = 20000;
        }
        else if (currentLevel < 8)
        {
            expToNextLevel += 20;
        }
        else if (currentLevel == 9)
        {
            expToNextLevel = 250;
        }
        else if (currentLevel < 16)
        {
            expToNextLevel += 50;
        }
        else if (currentLevel == 17)
        {
            expToNextLevel = 700;
        }
        else if (currentLevel < 25)
        {
            expToNextLevel += 100;
        }


        if (currentLevel==8){
             Invoke("spawnBoss", 1.5f);
        }

        UpdatePlayerStats();
    }

    // Function to update player stats based on the level
    private void UpdatePlayerStats()
    {
        health += 20; // Increase health by 10 for each level
        defense += 2; // Increase defense by 2 for each level
        currenthealth += 20;
        pops.PlayerLvl(currentLevel);
    }

    void Update()
    {
         regenerationTimer -= Time.deltaTime;

        if (regenerationTimer <= 0)
        {
            float previousHealth = currenthealth;
            currenthealth = Mathf.Min(currenthealth + regenerationAmount, health);

            // Ensure health doesn't go above the maximum
            if (currenthealth > health)
            {
                currenthealth = health;
            }

            HealthBar.UpdateHealthBar(currenthealth, health);
            regenerationTimer = regenerationCooldown;

            Debug.Log($"Health Regenerated: {previousHealth} -> {currenthealth}");
        }


    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount - defense;
        HealthBar.UpdateHealthBar(currenthealth, health);


        if(currenthealth <= 0)
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        P.BloodScreen();
    }

    void Start()
    {
        // Load saved level and exp, defaulting to 1 and 0 if not found

        LvlBar.UpdateHealthBar(currentExp, expToNextLevel);
        artificialBtn.onClick.AddListener(OnAttackButtonCLick); // temporary
    }

    

    //Temporary
    public void OnAttackButtonCLick()
    {
        Debug.Log("CLick");
        health += 200; // Increase health by 10 for each level
        defense += 20; // Increase defense by 2 for each level
        currenthealth += 200;
        pops.PlayerLvl(currentLevel = 8);

        Invoke("spawnBoss", 1.5f);
    }

    public void spawnBoss()
    {
        tempBoss.SetActive(true);
    }
}