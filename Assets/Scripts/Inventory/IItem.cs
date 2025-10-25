using UnityEngine;

public interface IItem
{
    public void Use(Transform raycastPosition, IUser user); 
    public GameObject ItemGameObject { get; }

}
