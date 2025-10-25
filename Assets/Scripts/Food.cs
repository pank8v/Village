using UnityEngine;

public class Food : MonoBehaviour, IItem
{
    private GameObject itemGameObject;
    public GameObject ItemGameObject => itemGameObject;

    private void Awake() {
        itemGameObject = gameObject;
    }

    public void Use(Transform raycastPosition, IUser user) {
        Debug.Log("Food used");
    }
}
