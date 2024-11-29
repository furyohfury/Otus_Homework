using UnityEngine;
namespace Game
{
    public class StickyBomb : MonoBehaviour
{
    [SerializeField] 
    private float explosionDamage = 5;

    [Header("Explosion Config")]
    [SerializeField] 
    private float explosionForce = 10.0f;
    [SerializeField] 
    private float explosionRadius = 10.0f;
    [SerializeField] 
    private float explosionDelay = 1f;
    [SerializeField] 
    private float explosionUpwardForce = 1.0f;


    [Header("FX")]
    [SerializeField]
    private AudioClip _stickingSound;
    [SerializeField] 
    private ParticleSystem explosionEffect;
    [SerializeField] 
    private AudioClip explosionSound;
    [SerializeField] [Range(0.0f, 1.0f)] 
    private float explosionVolume = 1.0f;

    [SerializeField]
    private Rigidbody rb;

    private bool stickingActivated = true;

    void Start()
    {
        rb.isKinematic = false;
        // set PS to stop action destroy
    }

    public void Explode()
    {        
        if (explosionEffect != null)
        {
            var effect = ParticleSystem.Instantiate(explosionEffect, transform.position, Quaternion.identity);

            if (explosionSound != null)
            {
                effect.AddComponent<AudioSource>().PlayOneShot(explosionSound, explosionVolume);
            }
        }
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (!hit.TryGetEntity(out IEntity entity))
            {
                continue;
            }

            if (entity.TryGetRigidbody(out Rigidbody2D rb))
            {
                rb.AddExplosionForce(explosionForce,
                transform.position, 
                explosionRadius,
                explosionUpwardForce);
                // TODO check if works on bullets
            }       

            if (entity.TryGetDestroyEvent(out var destroyEvent)) // TODO mb wall tag
            {
                destroyEvent.Invoke();
            }

            if (!entity.HasCharacterTag() && entity.TryGetTakeDamageRequest(out var request))
            {
                request.Invoke(_explosionDamage);
            }
                          
        }            

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!stickingActivated)
        {
            return;
        }

        rb.isKinematic = true;
        Explode();
    }
}
}