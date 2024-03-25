using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public Canvas canvas;
    public Transform inventorySlots;
    //[SerializeField] public Inventory _inventory;
    //private UpdateSlot[] slots;
    private bool _inInventory = false;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        //slots = inventorySlots.GetComponentsInChildren<UpdateSlot>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
}
