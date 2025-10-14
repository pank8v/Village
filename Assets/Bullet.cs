using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision) {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null) {
            damageable.TakeDamage(damage);
        }
    }
}
