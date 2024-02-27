using UnityEngine;

public enum AttackType { melee, distance }
public class EnemyData : ScriptableObject
{
    public AttackType type;
}