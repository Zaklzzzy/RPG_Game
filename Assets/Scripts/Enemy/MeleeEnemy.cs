using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Enemy", menuName = "Enemy/Melee", order = 51)]
public class MeleeEnemy : EnemyData
{
    private void Awake()
    {
        type = AttackType.melee;
    }
}
