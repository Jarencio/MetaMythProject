using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image bloodScreen;


    void Start()
    {
        bloodScreen = GetComponent<Image>();
    }

    public void BloodScreen()
    {
        bloodScreen.enabled = false;
        // Activate the blood screen
        bloodScreen.enabled = true;

        // Deactivate the blood screen after 1.5 seconds
        Invoke("DeactivateBloodScreen", 1.5f);
    }

    public void DeactivateBloodScreen()
    {
        // Deactivate the blood screen
        bloodScreen.enabled = false;
    }
}
