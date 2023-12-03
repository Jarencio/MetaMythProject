using UnityEngine;
using UnityEngine.UI;

public class Diactivte_AtkButtons  : MonoBehaviour
{
    public Button[] buttons;

    public void EnableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void DisableButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
}

