using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class BossBullet : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public float force;
    public int damage; // Add a damage variable
    public float timeToLive = 5f;
    public float timeToLives = 1f;

    public int type;
    public Action OnProjectileHitPlayer { get; internal set; }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Use Rigidbody velocity to move the bullet
            rb.velocity = direction * force;

            if (type == 0)
            {
                Destroy(gameObject, timeToLive);
            }
            else
            {
                Destroy(gameObject, timeToLives);
            }


        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterLevelSystem cls = collision.gameObject.GetComponent<CharacterLevelSystem>();
            if (cls != null)
            {
                Debug.Log("Damage: " + damage);
                cls.TakeDamage(damage);
            }

            Destroy(gameObject);

        }
        else
        {
            Debug.Log("No damage applied. Collision tag: " + collision.gameObject.tag);
        }
    }

}

