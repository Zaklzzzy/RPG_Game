using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //AI Navigation
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private float movementSpeed = 3.5f;

    //Damage and Health
    [SerializeField] private short HP;
    [SerializeField] private float attackSpeed;
    [SerializeField] private short damage;

    //Animation and Particles


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<PlayerController>().transform;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(agent.transform.position,player.position) < 12f)
        {
            agent.speed = 0f;
        }
        else
        {
            agent.speed = movementSpeed;
            
        }
        agent.transform.LookAt(player.position);
        agent.destination = player.position;
    }

    public void TakeDamage(short damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
