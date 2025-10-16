using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject itemPrefab;
    
    public string ItemName => itemName;
    public GameObject ItemPrefab => itemPrefab;
}
