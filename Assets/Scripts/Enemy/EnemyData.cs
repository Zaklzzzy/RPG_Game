using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { melee, distance }
public class EnemyData : ScriptableObject
{
    public AttackType type;
    public short movementSpeed;
    public short HP;
}