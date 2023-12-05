using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelestialRodController : MonoBehaviour
{
    public GameObject rod;
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public Button attackButton;
    public AudioSource ShootSound;
    public bool isOnCooldown = false;
    public float cooldownDuration = 20.0f;
    public float maxDistance = 2.0f;
    [SerializeField] float arrowSpeed = 30;

    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        ShootSound = GetComponent<AudioSource>();
        attackButton = GameObject.Find("AttackBtnRod").GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonClick);

    }


    public void OnAttackButtonClick()
    {
        
        if (canShoot && !isOnCooldown)
        {
            ShootArrow();
            
            StartCoroutine(StartCooldown());
            
        }

    }

    // Update is called once per frame
    public void ShootArrow()
    {
        ShootSound.Play();
        Animator anim = rod.GetComponent<Animator>();
        anim.SetTrigger("attack");

        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        // Limit the arrow's travel distance to 2 units        maxDistance = 2f;
        arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * Mathf.Min(arrowSpeed, maxDistance / Time.fixedDeltaTime);
    }

    public IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
        
    }

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }

}
