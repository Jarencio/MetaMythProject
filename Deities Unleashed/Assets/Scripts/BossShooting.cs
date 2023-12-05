using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject enemy;
    public GameObject ProjectilePrefab;
    public Transform ProjectilePos;
    public EnemyTarget enemyTarget; // Reference to EnemyTarget
    public float shootingDistanceThreshold = 10f;
    private float timer;
    public int type;

    void Start()
    {
        // Assuming EnemyTarget is on the same GameObject as EnemyShooting
        enemyTarget = GetComponent<EnemyTarget>();
        if (enemyTarget == null)
        {
            Debug.LogError("EnemyTarget script not found on the same GameObject as EnemyShooting.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Assuming the player has the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= shootingDistanceThreshold)
            {
                // Shoot every 5 seconds
                if (timer > 5)
                {
                    timer = 0;
                    Shoot();
                }
            }
            else
            {
                // Player is not within sight, stop shooting
                timer = 0;
            }
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }


    void Shoot()
    {
        GameObject projectileInstance = Instantiate(ProjectilePrefab, ProjectilePos.position, Quaternion.identity);

        // Pass the reference to EnemyTarget to the EnemyBullet script
        BossBullet BossBulletScript = projectileInstance.GetComponent<BossBullet>();
        if (BossBulletScript != null)
        {
            int minDamage = Mathf.RoundToInt(enemyTarget.MinDmg);
            int maxDamage = Mathf.RoundToInt(enemyTarget.MaxDmg);


            Debug.Log("Min:" + minDamage + " & Max:" + maxDamage);
            // Calculate damage within the OnCollisionEnter method
            int damage = Random.Range(minDamage, maxDamage);


            BossBulletScript.damage = damage;
            BossBulletScript.type = type;



        }
        else
        {
            Debug.LogError("EnemyBullet script not found on instantiated projectile.");
        }
    }
}
