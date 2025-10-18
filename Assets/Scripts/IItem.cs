using UnityEngine;

public interface IItem
{
    public void Use(Transform raycastPosition); 
    public GameObject ItemGameObject { get; }
  // public ItemSO ItemSO { get; }

}

public struct ItemContext
{
    public Transform rayCastPoint;
    public Vector3 attackPoint;
}