using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;    
    public Button attackButton;
    private AudioSource ShootSound;
    private bool isOnCooldown = false;
    private float cooldownDuration = 3.0f;
    [SerializeField] float arrowSpeed = 10;

    private void Start()
    {
        // Find the AttackButton by its name and attach the ShootArrow method to its click event
        ShootSound = GetComponent<AudioSource>();
        attackButton = GameObject.Find("AttackBtn").GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonClick);
        
    }

    private void OnAttackButtonClick()
    {
        if (!isOnCooldown)
        {
            ShootArrow();
            StartCoroutine(StartCooldown());
        }
    }

    // Update is called once per frame
    void ShootArrow()
    {
        ShootSound.Play();
        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        arrow.GetComponent<Rigidbody>().velocity = arrowSpawnPoint.forward * arrowSpeed;
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }
}
