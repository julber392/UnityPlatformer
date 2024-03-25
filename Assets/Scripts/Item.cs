using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    [SerializeField] public int ItemId;
    [SerializeField] public string Name;
    [SerializeField] public bool Stackable;
    [SerializeField] public Sprite Icon;
    [SerializeField] public bool CanEquip;
    [SerializeField] public Object PhysObj;
}
