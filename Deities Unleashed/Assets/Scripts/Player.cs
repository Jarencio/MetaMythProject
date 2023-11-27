using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bloodScreen;
    public Animator bloodAnim;
    public Image bloodImage;

    void Start()
    {
        bloodScreen = GetComponent<GameObject>();
        bloodAnim = GetComponent<Animator>();
        bloodImage = GetComponent<Image>();
    }

    public void BloodScreen()
    {
        //bloodScreen.SetActive(false);
        // Activate the blood screen
        //bloodScreen.SetActive(true);
        bloodImage.enabled = true;

        Invoke("ActivateBloodAnimation", 0.5f);
        

        // Deactivate the blood screen after 1.5 seconds
        Invoke("DeactivateBloodScreen", 1.0f);
    }

    public void DeactivateBloodScreen()
    {
        //Deactivate the blood screen
        //bloodScreen.SetActive(false);

        bloodImage.enabled =false;

        Invoke("DeactivateBloodAnimation", 0.5f);
    }

    public void ActivateBloodAnimation()
    {
        bloodAnim.enabled = true;
    }

    public void DeactivateBloodAnimation()
    {
        bloodAnim.enabled = false;
    }
}
