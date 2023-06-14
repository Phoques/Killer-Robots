using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public Transform[] waypoints;
    public Transform playerPos;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = playerPos.position;
    }
}
