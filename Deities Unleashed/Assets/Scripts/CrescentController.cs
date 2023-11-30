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
    int s;
    public CharacterLevelSystem CS;

    // Start is called before the first frame update
    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        CrescentAttackButton.onClick.AddListener(OnClickCrescentAttack);
    }

    public void OnClickCrescentAttack()
    {
        if (canAttack)
        {
            CrescentAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }

    public void CrescentAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = crescent.GetComponent<Animator>();
        anim.SetTrigger("attack");

    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
