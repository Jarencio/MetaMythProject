using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image[] weapons; // Array to store all weapon images
    public Button[] cooldownButtons; // Array to store all cooldown buttons
    [SerializeField] public float cooldown = 5.0f;
    private bool isCooldown = false;

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

    // Method to start the cooldown for all weapons
    void StartCooldown()
    {
        if (!isCooldown)
        {
            StartCoroutine(PerformCooldown());
        }
    }

    IEnumerator PerformCooldown()
    {
        isCooldown = true;

        // Gradually fill up all weapon images
        float timer = 0f;
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

        isCooldown = false;
    }
}
