using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour
{
   // public AudioSource sound;
    //This is the main script which pulls the objects nearby
    [SerializeField] public float GRAVITY_PULL = 100f;
    public static float m_GravityRadius = 1f;

    public void Start()
    {
 //       sound = GetComponent<AudioSource>();
    }

    void Awake() {
        m_GravityRadius = GetComponent<SphereCollider>().radius;

        if(GetComponent<SphereCollider>()){
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }
    
    void OnTriggerStay (Collider other) {
       // sound.Play();
        if(other.attachedRigidbody && other.GetComponent<SingularityPullable>()) {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
        }
    }
}
