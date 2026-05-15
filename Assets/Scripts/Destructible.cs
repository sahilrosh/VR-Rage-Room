using UnityEngine;

public class Destructible : MonoBehaviour
{
    [Header("Destruction")]
    public GameObject debrisPrefab;
    public float breakForce = 5f;
    public float debrisLifetime = 4f;

    [Header("Effects")]
    public ParticleSystem impactParticles;
    public AudioClip breakSound;

    private AudioSource audioSource;
    private bool broken = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f; // 3D sound
    }

    void OnCollisionEnter(Collision col)
    {
        if (broken) return;
        if (col.impulse.magnitude < breakForce) return;

        broken = true;

        // Spawn particles
        if (impactParticles != null)
            Instantiate(impactParticles, transform.position, Quaternion.identity);

        // Play break sound
        if (breakSound != null)
            AudioSource.PlayClipAtPoint(breakSound, transform.position);

        // Spawn debris
        if (debrisPrefab != null)
        {
            GameObject debris = Instantiate(debrisPrefab, transform.position, transform.rotation);

            // Give each debris piece a random force outward
            foreach (Rigidbody rb in debris.GetComponentsInChildren<Rigidbody>())
            {
                Vector3 force = (rb.transform.position - transform.position).normalized;
                force += Random.insideUnitSphere * 0.5f;
                rb.AddForce(force * col.impulse.magnitude * 0.5f, ForceMode.Impulse);
                rb.AddTorque(Random.insideUnitSphere * 3f, ForceMode.Impulse);
            }

            Destroy(debris, debrisLifetime);
        }
        
        ScoreManager.Instance?.AddScore(10);
        Destroy(gameObject);
    }
}