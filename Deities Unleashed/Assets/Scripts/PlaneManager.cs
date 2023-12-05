using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public int numberOfPlanes = 5;
    public GameObject[] planes;

    void Start()
    {
        // Initialize the array of planes
        planes = new GameObject[numberOfPlanes];

        // Create and configure planes
        for (int i = 0; i < numberOfPlanes; i++)
        {
            planes[i] = CreatePlane("Plane_" + i, i * 2.0f); // Adjust spacing as needed
        }
    }

    GameObject CreatePlane(string name, float xPosition)
    {
        // Create a plane
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        // Set the position and rotation
        plane.transform.position = new Vector3(xPosition, 0f, 0f);
        plane.transform.rotation = Quaternion.identity;

        // Disable Mesh Renderer
        MeshRenderer renderer = plane.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        // Disable rotation
        plane.AddComponent<FixedRotation>();

        // Set the name
        plane.name = name;

        return plane;
    }
}

// Script to prevent rotation
public class FixedRotation : MonoBehaviour
{
    void Update()
    {
        // Reset rotation to zero every frame
        transform.rotation = Quaternion.identity;
    }
}
