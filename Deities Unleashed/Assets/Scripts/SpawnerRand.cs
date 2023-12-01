using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRand : MonoBehaviour
{
    public GameObject theEnemy;

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
            // Respawn the item at a new position
            Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0.5f, UnityEngine.Random.Range(-5f, 5f));

            // Spawn a new item at the calculated position
            theEnemy = Instantiate(theEnemy, respawnPosition, Quaternion.identity);
            theEnemy.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
            enemyCount += 1;
        }

        while (enemyCount < 50) //Continious Spaawn
        {
            // Respawn the item at a new position
            Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0.5f, UnityEngine.Random.Range(-5f, 5f));

            // Spawn a new item at the calculated position
            theEnemy = Instantiate(theEnemy, respawnPosition, Quaternion.identity);
            theEnemy.SetActive(true);

            yield return new WaitForSeconds(spawnDelay);
            enemyCount += 1;
        }
    }

}
