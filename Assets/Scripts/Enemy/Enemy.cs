using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //AI Navigation
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] private float movementSpeed = 3.5f;

    //Damage and Health
    [SerializeField] private short HP;
    [SerializeField] private float attackSpeed;
    [SerializeField] private short damage;

    //Animation and Particles


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindFirstObjectByType<PlayerController>().transform;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(_agent.transform.position,_player.position) < 12f)
        {
            _agent.speed = 0f;
        }
        else
        {
            _agent.speed = movementSpeed;
            
        }
        _agent.transform.LookAt(_player.position);
        _agent.destination = _player.position;
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
