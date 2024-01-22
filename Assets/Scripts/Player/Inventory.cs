using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory: MonoBehaviour
{
    public List<InventorySlot> slots;

/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //slots[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //slots[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //slots[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //slots[3];
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("KeyCode.E");
                slots[0].itemOnSlot = other.GetComponent<Item>()._item;
                slots[0].GetComponent<Image>().sprite = other.GetComponent<Item>()._item.icon;
                Destroy(other.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                slots[1].itemOnSlot = other.GetComponent<Item>()._item;
                slots[1].GetComponent<Image>().sprite = other.GetComponent<Item>()._item.icon;
                Destroy(other.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                slots[2].itemOnSlot = other.GetComponent<Item>()._item;
                slots[2].GetComponent<Image>().sprite = other.GetComponent<Item>()._item.icon;
                Destroy(other.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                slots[3].itemOnSlot = other.GetComponent<Item>()._item;
                slots[3].GetComponent<Image>().sprite = other.GetComponent<Item>()._item.icon;
                Destroy(other.gameObject);
            }
        }
    }
}
