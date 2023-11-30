using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quit : MonoBehaviour
{
    public GameObject panel;

    public void Yes()
    {
        panel.SetActive(true);

    }

    public void No()
    {
       panel.SetActive(false);
    }
}
