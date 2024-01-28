using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private EnemyData data;

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
            agent.speed = 3.5f;
            
        }
        agent.transform.LookAt(player.position);
        agent.destination = player.position;
    }
}
