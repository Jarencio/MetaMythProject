using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrescentController : MonoBehaviour
{
    public AudioSource slashSound;

    public GameObject crescent;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    public Button CrescentAttackButton;
    public CharacterLevelSystem CS;

    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle", "Mayari", "Spawner", "NPC" };


    // Start is called before the first frame update
    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        CrescentAttackButton.onClick.AddListener(OnClickCrescentAttack);

        // Find the "Player" GameObject and get the attached "CharacterLevelSystem" script
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            CS = player.GetComponent<CharacterLevelSystem>();
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the GameObject is named 'Player' and has the 'CharacterLevelSystem' script attached.");
        }
    }

    public void OnClickCrescentAttack()
    {
        if (canAttack)
        {
            CrescentAttack();
            Sound();
            Invoke("Sound", 0.3f);
            StartCoroutine(StartCooldown());
        }
    }

    public void CrescentAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = crescent.GetComponent<Animator>();
        anim.SetTrigger("attack");

        int damage = CalculateSwordDamage();
        Debug.Log("Sword Damage: " + damage);

        DealDamage(damage);

        Invoke("DealSecondDamage", 0.5f);
    }

    public void DealSecondDamage()
    {
        int damage = CalculateSwordDamage();
        Debug.Log("Sword Damage: " + damage);

        DealDamage(damage);
    }

    public int CalculateSwordDamage()
    {
        int minDamage = 5 + (3 * CS.currentLevel);
        int maxDamage = 15 + (5 * CS.currentLevel);

        int damage = Random.Range(minDamage, maxDamage + 1);
        Debug.Log("Calculated Damage: " + damage);

        int criticalRoll = Random.Range(2, 6);
        Debug.Log("Critical Roll: " + criticalRoll);


        return damage;
    }

    void DealDamage(int damage)
    {
        // Check for collision with enemies
        Collider[] hitColliders = Physics.OverlapSphere(crescent.transform.position, crescent.GetComponent<BoxCollider>().size.x * 6);

        foreach (Collider collision in hitColliders)
        {
            bool isTarget = false;

            foreach (string targetTag in targetTags)
            {
                if (collision.gameObject.CompareTag(targetTag))
                {
                    isTarget = true;
                    break;
                }
            }

            if (isTarget)
            {
                EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                   /* if (s == 1)
                    {
                        enemyDamageReceiver.Burn();
                    }*/
                    Debug.Log("Applied Damage: " + damage);
                    // Additional logic can be added here if needed
                }
            }
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void Sound()
    {
        slashSound.Play();
    }

}
