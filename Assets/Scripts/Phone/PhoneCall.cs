using System.Collections;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class PhoneCall : MonoBehaviour
{
    private Phone _phone;
    private bool _isCalling = false;
    [SerializeField] private EventReference ringEvent;
    [SerializeField] private EventReference answerEvent;
    [SerializeField] private EventReference finishEvent;

    private EventInstance currentInstance;
    
    private void Awake() {
        _phone = GetComponent<Phone>();
        if (_phone) {
            _phone.OnPhoneCall += DialNumber;
        }
    }

    private void DialNumber(string number) {
        if (!_isCalling) {
            StartCoroutine(CallRoutine(number));
        }
    }

    
    private IEnumerator CallRoutine(string number) {
        _isCalling = true;
        currentInstance = RuntimeManager.CreateInstance(ringEvent);
        RuntimeManager.AttachInstanceToGameObject(currentInstance, gameObject.transform);
        currentInstance.start();
        float callDuration = (number == "1234") ? 3f : 5f;
        yield return new WaitForSeconds(5);
        currentInstance.stop(STOP_MODE.ALLOWFADEOUT);
        currentInstance.release();
        if (number == "1337228") {
            currentInstance = RuntimeManager.CreateInstance(answerEvent);
            RuntimeManager.AttachInstanceToGameObject(currentInstance, gameObject, transform);
            currentInstance.start();
            currentInstance.release();
            yield return new WaitForSeconds(14);
            currentInstance = RuntimeManager.CreateInstance(finishEvent);
            RuntimeManager.AttachInstanceToGameObject(currentInstance, gameObject.transform);
            currentInstance.start();
            currentInstance.release();
            
        }
        _isCalling = false;
    }
    
}
