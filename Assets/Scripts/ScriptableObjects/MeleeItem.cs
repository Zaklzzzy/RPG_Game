using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Items/Melee", order = 51)]
public class MeleeItem : ItemData
{
    public short damage;

    private void Awake()
    {
        type = ItemType.Melee;
    }
}
