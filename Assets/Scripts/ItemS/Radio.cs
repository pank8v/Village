using UnityEngine;

public class Radio : MonoBehaviour, IItem
{
    public GameObject ItemGameObject => gameObject;
    public void Use(Transform _, IUser user) {
        var inspector = user as IInspector;
        if (inspector != null) {
            inspector.InspectObject(ItemGameObject);
        }
    }
}
    
