using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Distance", menuName = "Distance", order = 51)]
public class DistanceData : ScriptableObject
{
    [SerializeField] private string distanceName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private short damage;

    public string DistanceName
    {
        get
        {
            return distanceName;
        }
    }
    public string Description
    {
        get
        {
            return description;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
    public short Damage
    {
        get
        {
            return damage;
        }
    }
}
