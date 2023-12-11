using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class CustomObserverEventHandler : DefaultObserverEventHandler
{
    // Reference to the GameObjects you want to enable/disable
    public GameObject[] gameObjectsToEnable;

    protected override void Start()
    {
        base.Start();

        // Disable the GameObjects initially
        DisableGameObjects();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Enable the GameObjects when the target is found
        EnableGameObjects();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        // Disable the GameObjects when the target is lost
        DisableGameObjects();
    }

    private void EnableGameObjects()
    {
        if (gameObjectsToEnable != null)
        {
            foreach (var gameObject in gameObjectsToEnable)
            {
                if (gameObject != null)
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }

    private void DisableGameObjects()
    {
        if (gameObjectsToEnable != null)
        {
            foreach (var gameObject in gameObjectsToEnable)
            {
                if (gameObject != null)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
