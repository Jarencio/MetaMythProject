using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    public CharacterLevelSystem characterLevelSystem;
    public float healthRegenInterval = 5f;
    public float healthRegenAmount = 5f;

public void Starting()
{
    // Start the coroutine when the script is initialized
    StartCoroutine(HealthRegenerationCoroutine());
}


 IEnumerator HealthRegenerationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(healthRegenInterval);

            // Check if current health is lower than total health
            if (characterLevelSystem.currenthealth < characterLevelSystem.health)
            {
                // Add healthRegenAmount to current health
                characterLevelSystem.currenthealth += healthRegenAmount;

                // Ensure current health does not exceed total health
                characterLevelSystem.currenthealth = Mathf.Min(characterLevelSystem.currenthealth, characterLevelSystem.health);

                // Update the health bar
                characterLevelSystem.HealthBar.UpdateHealthBar(characterLevelSystem.currenthealth, characterLevelSystem.health);

                // Debug information
                Debug.Log("Health Regeneration: " + healthRegenAmount + " health added. Current Health: " + characterLevelSystem.currenthealth);
            }
            else
            {
                Debug.Log("Health Regeneration: Not triggered. Current Health is already at maximum.");
            }
        }
    }
}
