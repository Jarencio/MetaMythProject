using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyTarget enemyTarget;
    public CharacterLevelSystem CLS;
    float maxDamage;
    float minDamage;
    int sd = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sd == 1)
        {
            if (enemyTarget != null)
            {
                maxDamage = enemyTarget.MaxDmg;
                minDamage = enemyTarget.MinDmg;

                // Use maxDamage and minDamage as needed
                Debug.Log($"Max Damage: {maxDamage}, Min Damage: {minDamage}");
            }
            else
            {
                Debug.LogError("EnemyTarget not assigned to AnotherScript!");
            }
            sd++;
        }
        }

        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int damage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage));
            CLS.TakeDamage(damage);
        }
    }
    }
