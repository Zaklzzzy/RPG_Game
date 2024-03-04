using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Default, Distance, Melee}
public abstract class ItemData : ScriptableObject
{
    public ItemType type;
    public string itemName;
    public string description;
    public Sprite icon;
}
