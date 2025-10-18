using UnityEngine;

public class Food : MonoBehaviour, IItem
{
    private GameObject itemPrefab;
    public GameObject ItemGameObject => itemPrefab;

    private void Awake() {
        itemPrefab = gameObject;
    }

    public void Use(Transform raycastPosition) {
        Debug.Log("Food used");
    }
}
