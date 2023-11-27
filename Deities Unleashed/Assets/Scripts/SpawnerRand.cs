using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRand : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(EnemyDrop()); 
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)  //Start Spawn
        {
            xPos = Random.Range(-11, 42);
            zPos = Random.Range(-15, 20);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
           
            yield return new WaitForSeconds(0.2f);
            enemyCount += 1;
        }

        while (enemyCount < 50) //Continious Spaawn
        {
            xPos = Random.Range(-11, 50);
            zPos = Random.Range(-15, 20);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);

            yield return new WaitForSeconds(5f);
            enemyCount += 1;
        }
    }

}
