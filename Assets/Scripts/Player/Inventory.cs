using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory: MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private Transform inventory;

    private bool isOpen = false;

    public List<InventorySlot> slots = new List<InventorySlot>();
    private void Start()
    {
        for (int i = 0; i < inventory.childCount; i++)
        {
            if(inventory.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventory.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                inventoryUI.SetActive(true);
            }
            else
            {
                inventoryUI.SetActive(false);
            }
        }
    }

    private void AddItem(ItemData _item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.isEmpty)
            {
                slot.item = _item;
                slot.isEmpty = !slot.isEmpty;
            }
        }
    }
}
