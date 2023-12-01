using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelestialRodController : MonoBehaviour
{
    public AudioSource slashSound;

    public GameObject rod;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    public Button CrescentAttackButton;
    int s;
    public CharacterLevelSystem CS;


    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        CrescentAttackButton.onClick.AddListener(OnClickRodAttack);
    }

    public void OnClickRodAttack()
    {
        if (canAttack && !isAttacking)
        {
            RodAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }

    public void RodAttack()
    {
        Animator anim = rod.GetComponent<Animator>();
        anim.SetTrigger("attack");

        var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * projectileSpeed;

    }

    IEnumerator StartCooldown()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }

    public void SetCanShoot(bool value)
    {
        canAttack = value;
    }

}
