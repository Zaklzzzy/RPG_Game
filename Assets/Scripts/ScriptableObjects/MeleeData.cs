using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee", menuName = "Melee", order = 51)]
public class MeleeData : ScriptableObject
{
    [SerializeField] private string meleeName;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private short damage;

    public string MeleeName
    {
        get
        {
            return meleeName;
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
