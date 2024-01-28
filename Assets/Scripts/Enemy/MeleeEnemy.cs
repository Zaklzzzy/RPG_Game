using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Enemy", menuName = "Enemy/Melee", order = 51)]
public class MeleeEnemy : EnemyData
{
    public short attackSpeed;

    private void Start()
    {
        type = AttackType.melee;
    }
}
