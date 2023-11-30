using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtonController : MonoBehaviour
{
    public Button attackButton1;
    public Button attackButton2;
    public Button attackButton3;
    public Button attackButton4;
    public Button attackButton5;

    public void Start()
    {
        SwitchAttackButtons(0);
    }
    // Call this function to switch the attack buttons
    public void SwitchAttackButtons(int currentWeaponIndex)
    {
        Debug.Log("SwitchAttackButtons called with index: " + currentWeaponIndex);

        if (currentWeaponIndex == 0)
        {
            Debug.Log("Enabling button 1");
            attackButton1.gameObject.SetActive(true);
            attackButton2.gameObject.SetActive(false);
            attackButton3.gameObject.SetActive(false);
            attackButton4.gameObject.SetActive(false);
            attackButton5.gameObject.SetActive(false);
        }
        else if (currentWeaponIndex == 1)
        {
            Debug.Log("Enabling button 2");
            attackButton1.gameObject.SetActive(false);
            attackButton2.gameObject.SetActive(true);
            attackButton3.gameObject.SetActive(false);
            attackButton4.gameObject.SetActive(false);
            attackButton5.gameObject.SetActive(false);
        }
        else if (currentWeaponIndex == 2)
        {
            Debug.Log("Enabling button 3");
            attackButton1.gameObject.SetActive(false);
            attackButton2.gameObject.SetActive(false);
            attackButton3.gameObject.SetActive(true);
            attackButton4.gameObject.SetActive(false);
            attackButton5.gameObject.SetActive(false);
        }
        else if (currentWeaponIndex == 3)
        {
            Debug.Log("Enabling button 4");
            attackButton1.gameObject.SetActive(false);
            attackButton2.gameObject.SetActive(false);
            attackButton3.gameObject.SetActive(false);
            attackButton4.gameObject.SetActive(true);
            attackButton5.gameObject.SetActive(false);
        }
        else if (currentWeaponIndex == 4)
        {
            Debug.Log("Enabling button 5");
            attackButton1.gameObject.SetActive(false);
            attackButton2.gameObject.SetActive(false);
            attackButton3.gameObject.SetActive(false);
            attackButton4.gameObject.SetActive(false);
            attackButton5.gameObject.SetActive(true);
        }
        // Add more conditions for other weapons if needed
        else
        {
            attackButton1.gameObject.SetActive(true);
            attackButton2.gameObject.SetActive(false);
            Debug.LogError("Invalid weapon index: " + currentWeaponIndex);
        }
    }
}
