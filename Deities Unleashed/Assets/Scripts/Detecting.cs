using UnityEngine;

public class Detecting : MonoBehaviour
{
    public Popup pop;
    public GameObject targetObject; // Assign your target GameObject in the Unity Editor
    //public SpawnerRand spawn;
    public int i = 0;


    void Update()
    {
        // Check if the target GameObject is active or not
        if (targetObject != null && targetObject.activeSelf)
        {
            // Your logic when the GameObject is active goes here
            int numberOfActiveChildren = GetNumberOfActiveChildren(targetObject);
            pop.ImageTrack(numberOfActiveChildren);

            if (i == 0)
            {
                //    spawn.Here();
                i++;
                            Debug.Log("NotMeh");
            }
        }
        else
        {
            // Your logic when the GameObject is not active goes here
            pop.NoImageTrack();
            i = 0;
            Debug.Log("Meh");
        }
    }

    // Function to get the number of active children in a GameObject
    private int GetNumberOfActiveChildren(GameObject parent)
    {
        if (parent != null)
        {
            int activeChildrenCount = 0;

            foreach (Transform child in parent.transform)
            {
                if (child.gameObject.activeSelf)
                {
                    activeChildrenCount++;
                }
            }

            return activeChildrenCount;
        }
        else
        {
            return 0;
        }
    }
}
