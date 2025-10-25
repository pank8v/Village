using UnityEngine;

public class FlashLight : MonoBehaviour, IItem
{
    [SerializeField] private Light light;
    public GameObject ItemGameObject => gameObject;

    private bool isActive;
    
    private void Awake() {
        light.enabled = false;
    }
    public void Use(Transform _, IUser user) {
        isActive = !isActive;
        light.enabled = isActive;
    }
    
}
