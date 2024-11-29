using UnityEngine;
namespace Game
{
    public class DestructibleWall : MonoBehaviour
    {
        [SerializeField]
        private Vector2 _velocityToDestroy;
        [SerializeField] 
        private ParticleSystem explosionEffect;
        [SerializeField] 
        private AudioClip explosionSound;

        private void DestroyWall()
        {
            if (explosionEffect != null)
            {
                var effect = ParticleSystem.Instantiate(explosionEffect, transform.position, Quaternion.identity);

                if (explosionSound != null)
                {
                    effect.AddComponent<AudioSource>().PlayOneShot(explosionSound, explosionVolume);
                }
            }

            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision2D collision)
        {
            if (!collision.TryGetEntity(out IEntity entity)
            || !entity.TryGetRigidbody(out Rigidbody2D rigidbody))
            {
                return;
            }

            if (CanDestroy(rigidbody.velocity))
            {
                DestroyWall();
            }
        }

        private bool CanDestroy(Vector2 velocity)
        {
            if (_velocityToDestroy.x > 0 && rigidbody.velocity.x > _velocityToDestroy.x
            || _velocityToDestroy.y > 0 && rigidbody.velocity.y > _velocityToDestroy.y)
            {
                return true;
            }

            return false;
        }

        private void OnValidate()
        {
            if (_velocityToDestroy.x != 0 && _velocityToDestroy.y != 0)
            {
                _velocityToDestroy = Vector2.zero;
                Debug.LogError("Wall can be destroyed only by velocity from one side")
            }
        }
    }
}