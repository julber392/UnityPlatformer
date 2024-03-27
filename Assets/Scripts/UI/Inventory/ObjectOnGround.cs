using UnityEngine;

public class ObjectOnGround : MonoBehaviour
{
    [SerializeField] public Item item;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.Icon;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.transform.tag == "triggerObject")
        {
            Inventory inventory = obj.GetComponentInChildren<Inventory>();
            if ((inventory.countSlot < inventory.sizeInventory) ||
                (item.stackable && inventory.CurrentItem.Contains(item)))
            {
                inventory.AddItem(item);
                Destroy(gameObject);
            }
        }
    }
}
