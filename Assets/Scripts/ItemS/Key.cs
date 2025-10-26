using UnityEngine;

public class Key : MonoBehaviour, IItem
{
    [SerializeField] private ItemData data;
    public ItemData ItemData => data;
    public GameObject ItemGameObject => gameObject;
    public void Use(Transform _, IUser user) {
        
    }
}
