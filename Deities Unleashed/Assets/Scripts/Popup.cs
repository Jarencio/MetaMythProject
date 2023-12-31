using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Popup : MonoBehaviour
{
    private TextMeshPro TextMesh;
    private TextMeshProUGUI Texts; // Change the type to TextMeshProUGUI
    public Text textComponent;
    private void Awake()
    {
        TextMesh = transform.GetComponent<TextMeshPro>();
        Texts = transform.GetComponent<TextMeshProUGUI>();
    }

    public void Setup(int Damage)
    {
        if (Damage > 800)
        {
            TextMesh.SetText("CRIT");
        }
        else
        {
            Damage = Damage * 100;
            TextMesh.SetText(Damage.ToString());
        }
    }

    public void Lvl(int Level)
    {
        // Set the text
        TextMesh.SetText("LVL. " + Level.ToString());
        // Flip the TextMesh sideways by changing the local scale
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void PlayerLvl(int Level)
    {
        Texts.SetText("LVL. " + Level.ToString());
    }


    public void Cooldown()
    {
        if (Texts != null)
        {
            Texts.text = "Currently in Weapon Switch Cooldown";
        }
        else
        {
            Debug.LogError("TextMesh component not assigned in the inspector!");
        }
    }

    public void ResetText()
    {
        if (Texts != null)
        {
            Texts.text = "";
        }
        else
        {
            Debug.LogError("TextMesh component not assigned in the inspector!");
        }
    }

public void NoImageTrack()
{
    if (textComponent != null)
    {
        textComponent.text = "No enemies detected. Time to scan";
        textComponent.color = new Color(1.0f, 0.5f, 0.5f); // Light Red
    }
    else
    {
        Debug.LogError("Text component not assigned in the inspector!");
    }
}


public void ImageTrack(int s)
{
    if (textComponent != null)
    {
        textComponent.text = "Image is scanned! Time to fight (" +s +" Enemies Left)";
        textComponent.color = new Color(0.0f, 1.0f, 0.0f, 1.0f); // Light Green
    }
    else
    {
        Debug.LogError("Text component not assigned in the inspector!");
    }
}

}