using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> slots;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private bool[] isEmpty;
    [SerializeField] private short nowActive = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            nowActive = 0;
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            nowActive = 1;
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            nowActive = 2;
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            nowActive = 3;
            slots[nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("KeyCode.Q");
            if (!isEmpty[nowActive])
            {
                slots[nowActive].itemOnSlot = null;
                slots[nowActive].GetComponent<UnityEngine.UI.Image>().sprite = null;
                objects[nowActive].transform.position = gameObject.transform.position;
                objects[nowActive].SetActive(true);
                objects[nowActive] = null;
                isEmpty[nowActive] = true;

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("KeyCode.E");
                if (isEmpty[nowActive])
                {
                    slots[nowActive].itemOnSlot = other.GetComponent<Item>()._item;
                    slots[nowActive].GetComponent<UnityEngine.UI.Image>().sprite = other.GetComponent<Item>()._item.icon;
                    objects[nowActive] = other.gameObject;
                    objects[nowActive].SetActive(false);
                    isEmpty[nowActive] = false;

                }
            }
        }
    }
}
