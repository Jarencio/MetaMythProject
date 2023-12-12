using System.Collections;
using UnityEngine;

public class SpawnerRand : MonoBehaviour
{
    public GameObject[] theEnemy;
    public Transform parentTransform; // Reference to the parent transform
    public Transform UnparentTransform; // Reference to the parent transform 
    public GameObject targetObject;
    public int enemyCount;
    public float spawnDelay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

IEnumerator EnemyDrop()
{
    while (enemyCount < 3)  // Start Spawn
    {
        // Respawn the item at the same position as the SpawnerRand object
        Vector3 respawnPosition = transform.position;

        // Spawn a new item at the calculated position
        GameObject newEnemy = Instantiate(theEnemy[Random.Range(0, theEnemy.Length)], respawnPosition, Quaternion.identity);

        // Set the parent of the newEnemy to the specified parentTransform
        if(targetObject != null && targetObject.activeSelf){
        newEnemy.transform.SetParent(parentTransform);
        } else{
        newEnemy.transform.SetParent(UnparentTransform);
        }
        // Set the newEnemy to active
        newEnemy.SetActive(true);

        yield return new WaitForSeconds(spawnDelay);
        enemyCount += 1;
    }

    while (enemyCount < 50) // Continuous Spawn
    {
        // Respawn the item at the same position as the SpawnerRand object
        Vector3 respawnPosition = transform.position;

        // Spawn a new item at the calculated position
        GameObject newEnemy = Instantiate(theEnemy[Random.Range(0, theEnemy.Length)], respawnPosition, Quaternion.identity);

        // Set the parent of the newEnemy to the specified parentTransform
        if(targetObject != null && targetObject.activeSelf){
        newEnemy.transform.SetParent(parentTransform);
        } else{
        newEnemy.transform.SetParent(UnparentTransform);
        }
        // Set the newEnemy to active
        newEnemy.SetActive(true);

        yield return new WaitForSeconds(spawnDelay);
        enemyCount += 1;
    }

}

    public void Here(){
        StartCoroutine(EnemyDrop());
    }
    }
