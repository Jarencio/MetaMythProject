using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class SingularityCore : MonoBehaviour
{
    public CharacterLevelSystem CS;
    [SerializeField] int minDamage; // Minimum damage
    [SerializeField] int maxDamage; // Maximum damage
    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle" ,"Mayari", "Spawner" };
    private bool damageApplied = false; // Flag to track if damage has already been applied

void OnTriggerStay(Collider other)
{
    if (other.GetComponent<SingularityPullable>())
    {

        minDamage = 2 + (3 * CS.currentLevel);
        maxDamage = 10 + (5 * CS.currentLevel);
        Debug.Log("" + minDamage + " & " + maxDamage);

        // Check if damage has already been applied
        if (damageApplied)
            return;

        // Generate a random damage value between minDamage and maxDamage
        int damage = Random.Range(minDamage, maxDamage + 1); // +1 to include the maximum value
        foreach (string targetTag in targetTags)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                EnemyTarget enemyDamageReceiver = other.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);
                    damageApplied = true; // Set the flag to true to indicate damage has been applied
                }
            }
        }
    }
}

    void Awake(){
        if(GetComponent<SphereCollider>()){
            GetComponent<SphereCollider>().isTrigger = true;
        }

        GameObject player = GameObject.Find("Player");
        
        if (player != null)
        {
            CS = player.GetComponent<CharacterLevelSystem>();
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the GameObject is named 'Player' and has the 'CharacterLevelSystem' script attached.");
        }

    }

}
