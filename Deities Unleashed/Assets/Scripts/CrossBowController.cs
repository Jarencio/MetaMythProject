using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossBowController : MonoBehaviour
{
    public GameObject rod;
    

    public void CrossbowAttack()
    {
        Animator anim = rod.GetComponent<Animator>();
        anim.SetTrigger("attack");
    }
}
