using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChase : MonoBehaviour
{
    public Transform Player;
    [SerializeField] int MoveSpeed = 4;
    [SerializeField] int MaxDist = 10;
    [SerializeField] int MinDist = 5;
    [SerializeField] float ChaseRange = 15f; // New variable for the chasing range

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer <= ChaseRange)
        {
            transform.LookAt(Player);

            if (distanceToPlayer >= MinDist)
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (distanceToPlayer <= MaxDist)
                {
                    // Here you can call any function you want, such as shooting
                }
            }
        }
    }
}
