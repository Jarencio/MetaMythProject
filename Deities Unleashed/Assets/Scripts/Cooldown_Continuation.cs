using UnityEngine;
using System.Collections;


public class Cooldown_Continuation : MonoBehaviour
{
    // Reference to the Cooldown script
    public Cooldown cooldownScript;
    public int indecator = 0;
    public int indecator2 = 0;
    public float currentCooldownTime;
    
    void Update()
    {
        // Check if the Cooldown script is attached and the GameObject is inactive
        if (cooldownScript != null && !cooldownScript.gameObject.activeSelf)
        {
            // Access the isCooldown variable from the Cooldown script
            bool isCooldownActive = cooldownScript.isCooldown;

            // If cooldown is active, debug the current cooldown duration
            if (isCooldownActive)
            {
                if(indecator2==0){
                currentCooldownTime = cooldownScript.cooldown - cooldownScript.timer;
                Debug.Log($"Cooldown is active while the GameObject is inactive. Current cooldown time: {currentCooldownTime} seconds");
                indecator = 1;
                StartCoroutine(CountdownTimer());
                indecator2 = 1;
                }
            }
            else
            {
            }
        } else if(indecator==1){
        if (cooldownScript != null && cooldownScript.gameObject.activeSelf){
          cooldownScript.StoreTimerValue(currentCooldownTime);
            indecator = 0;
            indecator2 = 0;
        } 
        }

        IEnumerator CountdownTimer(){

            while(currentCooldownTime>0){
            yield return new WaitForSeconds(1f); // Wait for 1 second
            currentCooldownTime -= 1f;
            }
        }
    }
}
