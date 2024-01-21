using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Distance", menuName = "Items/Distance", order = 51)]
public class DistanceItem : ItemData
{
    public short damage;

    private void Start()
    {
        type = ItemType.Distance;
    }
}