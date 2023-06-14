using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;
    public Transform playerPos;
    public Transform enemyPos;

    public EnemyAI enemyAiClass;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAiClass = FindObjectOfType<EnemyAI>();
    }

    private void Update()
    {
        if (enemyAiClass.IsPlayerInRange())
        {
            navMeshAgent.destination = playerPos.position;
        }
        if (!enemyAiClass.IsPlayerInRange())
        {
            //Run Coroutine to navmesh destination null, say audio, wait for seconds, Start following waypoints again.
            navMeshAgent.destination = enemyPos.position;
        }
    }
}
