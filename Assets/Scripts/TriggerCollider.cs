using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    [SerializeField] private InteractableUI interactableUI;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) { 
            interactableUI.SetPlayerNearby(true);
            interactableUI.ShowWhiteDot();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            interactableUI.SetPlayerNearby(false);
            interactableUI.HideWhiteDot();
        }
    }
}
