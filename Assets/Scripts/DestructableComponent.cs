using UnityEngine;

public class DestructableComponent : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject destructablePrefab;
    public void TakeDamage(float _) {
        Instantiate(destructablePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
