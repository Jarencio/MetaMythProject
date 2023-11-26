using UnityEngine;

public class ExpParticleCollision : MonoBehaviour
{

    public GameObject ExpParticles;
    public Transform spawnExp;

    public void SpawnExpParticles()
    {
        if (ExpParticles != null && spawnExp != null)
        {
            Instantiate(ExpParticles, spawnExp.position, Quaternion.identity);
            ExpParticles.SetActive(true);
        }
    }
}
