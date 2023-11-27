using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bloodScreen;

    public void BloodScreen()
    {

        // Activate the blood screen
        bloodScreen.SetActive(true);
        

        // Deactivate the blood screen after 1.5 seconds
        Invoke("DeactivateBloodScreen", 0.5f);
    }

    public void DeactivateBloodScreen()
    {
        //Deactivate the blood screen
        bloodScreen.SetActive(false);

    }


}
