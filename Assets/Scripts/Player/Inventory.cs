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
    private short nowActive = 0;
    private GameObject nowItem;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isEmpty[nowActive])
            {
                slots[nowActive].itemOnSlot = nowItem.GetComponent<Item>()._item;
                slots[nowActive].GetComponent<UnityEngine.UI.Image>().sprite = nowItem.GetComponent<Item>()._item.icon;
                objects[nowActive] = nowItem.gameObject;
                objects[nowActive].SetActive(false);
                isEmpty[nowActive] = false;

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) nowItem = other.gameObject;
    }
}
