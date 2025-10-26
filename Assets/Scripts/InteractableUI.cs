using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    private bool isPlayerNearby = false;

    [SerializeField] private Canvas whiteDotCanvas;

    
    private void Start() {
        SetCanvasState(whiteDotCanvas, false);
    }


    private void SetCanvasState(Canvas canvas, bool state) {
        if (canvas != null && canvas.gameObject.activeSelf != state) {
            canvas.gameObject.SetActive(state);
        }
    }


    public void ShowWhiteDot() {
        if (isPlayerNearby) {
            SetCanvasState(whiteDotCanvas, true);
        }
    }

    public void HideWhiteDot() {
        SetCanvasState(whiteDotCanvas, false);
    }

    public void SetPlayerNearby(bool isNearby) {
        isPlayerNearby = isNearby;
        if (!isNearby) {
            HideWhiteDot();
        }
    }
    
    
}
