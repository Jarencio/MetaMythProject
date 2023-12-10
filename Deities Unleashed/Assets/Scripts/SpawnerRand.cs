using System.Collections;
using UnityEngine;

public class SpawnerRand : MonoBehaviour
{
    public GameObject[] theEnemy;
    public Transform parentTransform; // Reference to the parent transform

    public int enemyCount;
    public float spawnDelay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)  //Start Spawn
        {
            // Choose a random index from the enemies array
            int randomEnemyIndex = Random.Range(0, theEnemy.Length);

            // Respawn the item at a new position
            Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-25, 25), 0.5f, UnityEngine.Random.Range(-10, -20));
            Debug.Log("Respawn Position: " + respawnPosition);

            // Spawn a new item at the calculated position
            GameObject newEnemy = Instantiate(theEnemy[randomEnemyIndex], respawnPosition, Quaternion.identity);

            // Set the parent of the newEnemy to the specified parentTransform
            newEnemy.transform.SetParent(parentTransform);

            // Set the newEnemy to active
            newEnemy.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
            enemyCount += 1;
        }

        while (enemyCount < 50) //Continuous Spawn
        {
            // Choose a random index from the enemies array
            int randomEnemyIndex = Random.Range(0, theEnemy.Length);

            // Respawn the item at a new position
            Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-25, 25), 0.5f, UnityEngine.Random.Range(-10f, -20f));
            Debug.Log("Respawn Position: " + respawnPosition);
            // Spawn a new item at the calculated position
            GameObject newEnemy = Instantiate(theEnemy[randomEnemyIndex], respawnPosition, Quaternion.identity);

            // Set the parent of the newEnemy to the specified parentTransform
            newEnemy.transform.SetParent(parentTransform);

            // Set the newEnemy to active
            newEnemy.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
            enemyCount += 1;
        }
    }
}
