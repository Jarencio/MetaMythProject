using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public GameObject HitPartcle;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tiyanak" || other.tag == "BalBal"
            || other.tag == "TikTik" || other.tag == "Phoenix"
            || other.tag == "Golemn" || other.tag == "Wolf"
            || other.tag == "Cyclops" || other.tag == "ElectricGolem" || other.tag == "Eagle")
        {
            Debug.Log(other.name);
            //other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitPartcle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
    
    
}
