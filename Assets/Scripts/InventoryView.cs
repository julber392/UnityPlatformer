using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public Canvas canvas;
    public Transform inventorySlots;
    //[SerializeField] public Inventory _inventory;
    //private UpdateSlot[] slots;
    private bool _inInventory = false;
    private Animator animator;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        //slots = inventorySlots.GetComponentsInChildren<UpdateSlot>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled = !canvas.enabled;
        }
    }
    private General general
    {
        get { return (General)animator.GetInteger("General"); }
        set { animator.SetInteger("General", (int)value); }
    }
    public enum General
    {
        Open,
        Idle,
        Close,
        End
    }
}
