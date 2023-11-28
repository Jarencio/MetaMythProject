using UnityEngine;

public class Detecting : MonoBehaviour
{
    public Popup pop;
    public GameObject targetObject; // Assign your target GameObject in the Unity Editor

    void Update()
    {
        // Check if the target GameObject is active or not
        if (targetObject != null && targetObject.activeSelf)
        {
            // Your logic when the GameObject is active goes here
            pop.ImageTrack();
        }
        else
        {
            // Your logic when the GameObject is not active goes here
            pop.NoImageTrack();
        }
    }
}
