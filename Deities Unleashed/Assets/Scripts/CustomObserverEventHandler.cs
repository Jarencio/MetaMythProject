using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class CustomObserverEventHandler : DefaultObserverEventHandler
{
    // Reference to the GameObject you want to enable/disable
    public GameObject gameObjectToEnable;

    protected override void Start()
    {
        base.Start();

        // Disable the GameObject initially
        DisableGameObject();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Enable the GameObject when the target is found
        EnableGameObject();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        // Disable the GameObject when the target is lost
        DisableGameObject();
    }

    private void EnableGameObject()
    {
        if (gameObjectToEnable != null)
            gameObjectToEnable.SetActive(true);
    }

    private void DisableGameObject()
    {
        if (gameObjectToEnable != null)
            gameObjectToEnable.SetActive(false);
    }
}
