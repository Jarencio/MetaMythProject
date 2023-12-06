using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SunController : MonoBehaviour
{

    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public Button attackButton;
    public AudioSource ShootSound;
    public bool isOnCooldown = false;
    public float cooldownDuration = 2.0f;

    public GameObject sword;
    public GameObject kamays;

    [SerializeField] float arrowSpeed = 30;

    public bool canShoot = true;

    void Start()
    {
        ShootSound = GetComponent<AudioSource>();
        attackButton = GameObject.Find("AttackBtn 5").GetComponent<Button>();
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

        Animator anim1 = sword.GetComponent<Animator>();
        anim1.SetTrigger("attack");

        kamays.SetActive(true);
        Animator anim2 = kamays.GetComponent<Animator>();
        anim2.SetTrigger("kamays");

        Invoke("DisableKamays", 10.0f);

        // Instantiate the arrow
        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        // Get the arrow's rigidbody
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        if (arrowRigidbody != null)
        {
            // Set the arrow's velocity to drop downward at a high speed
            arrowRigidbody.velocity = Vector3.down * arrowSpeed; // Adjust the speed as needed
        }
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

    public void DisableKamays()
    {
        kamays.SetActive(false);
    }

}

