using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunController : MonoBehaviour
{
    public AudioSource slashSound;

    public GameObject sword;
    public GameObject kamays;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    public Button swordAttackButton;
    public GameObject spawner;


    // Start is called before the first frame update
    void Start()
    {
        swordAttackButton.onClick.AddListener(OnClickSwordAttack);
    }

    public void OnClickSwordAttack()
    {
        if (canAttack)
        {
            SwordAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }


    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim1 = sword.GetComponent<Animator>();
        anim1.SetTrigger("attack");
        spawner.SetActive(true);
        kamays.SetActive(true);
        Animator anim2 = kamays.GetComponent<Animator>();
        anim2.SetTrigger("kamays");

        Invoke("DisableKamays", 10.0f);
        Invoke("DisableSpawner", 10.0f);
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void DisableKamays()
    {
        kamays.SetActive (false);
    }

    public void DisableSpawner()
    {
        spawner.SetActive(false);
    }
}
