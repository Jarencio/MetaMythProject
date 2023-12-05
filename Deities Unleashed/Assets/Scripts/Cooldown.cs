using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image[] weapons; // Array to store all weapon images
    public Button[] cooldownButtons; // Array to store all cooldown buttons
    [SerializeField] public float cooldown = 5.0f;
    public bool isCooldown = false;
    public float timer;
    // Variable to store the current timer value
    public float currentTimerValue;
    public Button[] pressable;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize fill amounts for all weapons
        foreach (Image weapon in weapons)
        {
            weapon.fillAmount = 1;
        }

        // Add onClick listeners to the cooldown buttons
        foreach (Button button in cooldownButtons)
        {
            button.onClick.AddListener(StartCooldown);
        }
    }

    public void Fill()
    {
        foreach (Image weapon in weapons)
        {
            weapon.fillAmount = 1;
        }
    }

    // Method to start the cooldown for all weapons
    void StartCooldown()
    {
        if (!isCooldown)
        {
            StartCoroutine(PerformCooldown());
        }
    }

    // Coroutine to perform the cooldown
    IEnumerator PerformCooldown()
    {
        foreach (Button button in pressable)
        {
            button.interactable = false;
        }

        isCooldown = true;

        // Continue the cooldown from the stored timer value
     timer = currentTimerValue;
        while (timer < cooldown)
        {
            timer += Time.deltaTime;

            // Set fill amount for each weapon
            foreach (Image weapon in weapons)
            {
                weapon.fillAmount = timer / cooldown;
            }

            yield return null;
        }

        // Reset fill amounts for all weapon images immediately
        foreach (Image weapon in weapons)
        {
            weapon.fillAmount = 1;
        }

        foreach (Button button in pressable)
        {
            button.interactable = true;
        }

        isCooldown = false;
        currentTimerValue = 0;
    }

    // Method to store the current timer value
    public void StoreTimerValue(float timerValue)
    {
        currentTimerValue = cooldown - timerValue;
        StartCoroutine(PerformCooldown());
    }
}
