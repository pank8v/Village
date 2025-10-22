using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private float pushPower = 2f;
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) return;
        if (hit.moveDirection.y < -0.3f) return;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.linearVelocity = pushDirection * pushPower;
    }
}
