using UnityEngine;
using System.Collections;

public class FreezePositionOnHit : MonoBehaviour
{
    private bool isFrozen = false;
    public Rigidbody rb;

    // Assuming you've assigned the Rigidbody component in the Unity editor or set it programmatically
    // You can also add a check to ensure rb is not null before using it

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {  
    }

    private void OnCollisionEnter(Collision collision)
    {
            StartCoroutine(FreezePositionForOneSecond());   
    }

    private IEnumerator FreezePositionForOneSecond()
    {
        // Freeze the position and rotation
        isFrozen = true;
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Unfreeze the position and rotation
        if (rb != null)
        {
    rb.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
        }
        isFrozen = false;
    }
}
