using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterLevelSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentExp = 0;
    public int expToNextLevel = 20;

    // Player stats
    public float health = 150;
    public float defense = 4;

    // Function to gain experience points
    public void GainExperience(int expAmount)
    {
        if (currentLevel < 25)
        {
            currentExp += expAmount;
            Debug.Log("Gained " + expAmount + " experience points. Total experience: " + currentExp);
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

        // Update player stats based on the level
        UpdatePlayerStats();
    }

    // Function to update player stats based on the level
    private void UpdatePlayerStats()
    {
        health += 20; // Increase health by 10 for each level
        defense += 2; // Increase defense by 2 for each level
    }

   
}
