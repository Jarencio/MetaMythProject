using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject deadScreen;
    public Transform[] deleteParents;

    public void RestartLevel()
    {
        // 1. Unactivate a reference game object Dead_Screen
        deadScreen.SetActive(false);

        // 2. Delete all the children in the array of game objects DeleteParents
        foreach (Transform parent in deleteParents)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }

        // 3. Reference CharacterLevelSystem and make currenthealth = health
        CharacterLevelSystem levelSystem = FindObjectOfType<CharacterLevelSystem>();
        if (levelSystem != null)
        {
            levelSystem.currenthealth = levelSystem.health;
            levelSystem.currentExp = 0;

            // 4. Update the bars
            levelSystem.LvlBar.UpdateHealthBar(levelSystem.currentExp, levelSystem.expToNextLevel);
            levelSystem.HealthBar.UpdateHealthBar(levelSystem.currenthealth, levelSystem.health);
        }

        // Note: The scene reloads without any visible changes, but the script is executed from the beginning
    }
}
