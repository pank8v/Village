using UnityEngine;
using DG.Tweening;
public class HidingSystem : MonoBehaviour
{
    [SerializeField] private float positionDuration = 0.3f;
    [SerializeField] private float rotationDuration = 0.5f;
    private bool isHiding = false;
    private CharacterController controller;
    private Vector3 lastPosition;
    private void Awake() {
        controller = GetComponent<CharacterController>();
    }
    
    
    
    public void ToggleHide(Transform hidingPoint) {
        if (controller) {
            if (!isHiding) {
                lastPosition = transform.position;
                isHiding = true;
                controller.enabled = false;
                Vector3 targetRotation = transform.localEulerAngles + new Vector3(0, 180, 0);
                Sequence sequence = DOTween.Sequence();
                sequence.Join(transform.DOLocalRotate(targetRotation, rotationDuration, RotateMode.FastBeyond360));
                sequence.Join(transform.DOMove(hidingPoint.position, positionDuration).SetEase(Ease.InOutSine));
                sequence.OnComplete(() =>
                {
                    controller.enabled = true;
                });
                
                var playerController = GetComponent<PlayerController>();
                if (playerController != null) {
                    playerController.enabled = false;
                }
            }
            else {
                isHiding = false;
                controller.enabled = false;
                transform.DOMove(lastPosition, positionDuration).SetEase(Ease.InOutSine).OnComplete(() =>
                {
                    controller.enabled = true;
                    var playerController = GetComponent<PlayerController>();
                    if (playerController != null) {
                        playerController.enabled = true;
                    }
                });
            }
            
        }
       
    }
}
