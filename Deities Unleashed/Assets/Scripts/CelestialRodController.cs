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

    // Start is called before the first frame update
    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        CrescentAttackButton.onClick.AddListener(OnClickRodAttack);
    }

    public void OnClickRodAttack()
    {
        if (canAttack)
        {
            RodAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }

    public void RodAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = rod.GetComponent<Animator>();
        anim.SetTrigger("attack");

    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
