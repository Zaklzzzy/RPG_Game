using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> _slots;
    [SerializeField] private List<Item> _objects;
    [SerializeField] private bool[] _isEmpty;
    private short _nowActive = 0;
    private Item _nowItem;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            _nowActive = 0;
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            _nowActive = 1;
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            _nowActive = 2;
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.white;
            _nowActive = 3;
            _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_isEmpty[_nowActive])
            {
                _slots[_nowActive].itemOnSlot = null;
                _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().sprite = null;
                _objects[_nowActive].transform.position = gameObject.transform.position;
                _objects[_nowActive].gameObject.SetActive(true);
                _objects[_nowActive] = null;
                _isEmpty[_nowActive] = true;

            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_isEmpty[_nowActive])
            {
                _slots[_nowActive].itemOnSlot = _nowItem.item;
                _slots[_nowActive].GetComponent<UnityEngine.UI.Image>().sprite = _nowItem.item.icon;
                _objects[_nowActive] = _nowItem.gameObject.GetComponent<Item>();
                _objects[_nowActive].gameObject.SetActive(false);
                _isEmpty[_nowActive] = false;

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) _nowItem = other.gameObject.GetComponent<Item>();
    }
}
