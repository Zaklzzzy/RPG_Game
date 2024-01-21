using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData item;
    public bool isEmpty = true;

    private void Start()
    {
        if(isEmpty)
        {
            gameObject.GetComponent<Image>().sprite = item.icon;
        }
    }
}