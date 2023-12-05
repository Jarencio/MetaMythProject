using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBCSpawner : MonoBehaviour
{
    public GameObject BBC;
    public int Count;

    public float spawnDelay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        // Respawn the item at a new position
        Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0.5f, UnityEngine.Random.Range(-5f, 5f));

        // Spawn a new item at the calculated position
        BBC = Instantiate(BBC, respawnPosition, Quaternion.identity);

        // Set Count to prevent further spawning
        Count = 3;

        // Modify Rigidbody properties for faster dropping
        Rigidbody bbcRigidbody = BBC.GetComponent<Rigidbody>();
        if (bbcRigidbody != null)
        {
            // Increase initial velocity in the downward direction
            bbcRigidbody.velocity = new Vector3(0, -300.0f, 0); // You can experiment with different velocity values

            // Alternatively, you can apply a force in the downward direction
            bbcRigidbody.AddForce(Vector3.down * 50.0f, ForceMode.VelocityChange);
        }

        Destroy(BBC, 5.0f);

        yield return null;
    }
}
