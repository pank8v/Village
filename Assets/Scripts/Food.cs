using UnityEngine;

public class Food : MonoBehaviour, IItem
{
   [SerializeField] private ItemSO itemSO;
   public ItemSO ItemSO => itemSO;
   
   public void Use() {
      Debug.Log("Food used");
   }

   public GameObject GameObject => this.GameObject;
}
