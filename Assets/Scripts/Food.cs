using UnityEngine;

public class Food : MonoBehaviour, IItem
{
    [SerializeField] private ItemData data;
    public ItemData ItemData => data;
    private GameObject itemGameObject;
    public GameObject ItemGameObject => itemGameObject;

    private void Awake() {
        itemGameObject = gameObject;
    }

    public void Use(Transform raycastPosition, IUser user) {
        Debug.Log("Food used");
    }
}
