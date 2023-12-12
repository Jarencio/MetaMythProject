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
            pop.ImageTrack();
            if(i==0){
        //    spawn.Here();
            i++;
            }

        }
        else
        {
            // Your logic when the GameObject is not active goes here
            pop.NoImageTrack();
            i = 0;
             }
        }
    }

