using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PhoneButtonType buttonType;
    [SerializeField] private int digit;
    private Phone phone;

    private void Awake() {
        phone = GetComponentInParent<Phone>();
    }
   
   
   
    public void OnPointerClick(PointerEventData eventData) {
        switch (buttonType) {
            case PhoneButtonType.Digit:
                phone.OnDigitButton(digit);
                break;
            case PhoneButtonType.Call:
                phone.OnCallButton();
                break;
            case PhoneButtonType.Clear :
                phone.OnClearButton();
                break;
        }
    }
}
