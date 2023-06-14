using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{

    public enum EnemyState
    {
        Patrol,
        Search,
        Chase
    }

   public EnemyState enemyState;

    private NavMeshAgent navMeshAgent;
    public EnemyAI enemyAiClass;

    public Transform[] waypoints;
    public Transform playerPos;
    public Transform enemyPos;
    public Transform post;
    public Vector3 lastKnownPos;

    private bool foundPlayer = false;
    private bool lookingForPlayer = false;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAiClass = FindObjectOfType<EnemyAI>();
    }

    private void Update()
    {

        RobotState();

        /*if (enemyAiClass.IsPlayerInRange())
        {
            EnemyState(Chase)
            foundPlayer = true;
            navMeshAgent.destination = playerPos.position;
        }
        if (!enemyAiClass.IsPlayerInRange() && foundPlayer)
        {
            lookingForPlayer = true;
        }
        if (!enemyAiClass.IsPlayerInRange() && lookingForPlayer)
        {
            YellowAlert();
        }
        if (!enemyAiClass.IsPlayerInRange() && !foundPlayer)
        {
            return;
        }*/
    }




    public IEnumerator LostPlayer()
    {
        lookingForPlayer = false;
        //This currently isnt working
        Debug.Log("Starting Coroutine");
        navMeshAgent.destination = playerPos.position;
        Debug.Log("Finding last Position");
        yield return new WaitForSeconds(10);
        //Play sound
        foundPlayer = false;
        navMeshAgent.destination = enemyPos.position;
        Debug.Log("Lost Position");
        yield return new WaitForSeconds(2);
        Debug.Log("Returning to Patrol.");
        navMeshAgent.destination = post.position;
        //Play sound, go back to patrol.


    }

    public void YellowAlert()
    {
        Debug.Log("Yellow Alert!");
        StartCoroutine(LostPlayer());
    }


    private void RobotState()
    {
        if (enemyAiClass.IsPlayerInRange())
        {
            enemyState = EnemyState.Chase;
            foundPlayer = true;
            
        }
        if (!enemyAiClass.IsPlayerInRange() && foundPlayer)
        {
            enemyState = EnemyState.Search;
        }
        if (!enemyAiClass.IsPlayerInRange() && lookingForPlayer)
        {
            //YellowAlert();
        }
        if (!enemyAiClass.IsPlayerInRange() && !foundPlayer)
        {
            return;
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = playerPos.position;
    }

    private void SearchForPlayer()
    {
        playerPos.position = lastKnownPos;
        navMeshAgent.destination = lastKnownPos;
    }

    private void ChangeState()
    {
        switch (enemyState)
        {
            case EnemyState.Patrol:
                {
                    //Patrol
                }
                break;
            case EnemyState.Chase:
                {
                    ChasePlayer();
                }
                break;
            case EnemyState.Search:
                {
                    //Search
                }
                break;
            default:
                {
                    Debug.LogWarning("Something went Wrong");
                }
                break;
        }
    }
}
