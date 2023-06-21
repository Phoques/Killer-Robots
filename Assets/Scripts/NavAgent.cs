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

    public NavMeshAgent navMeshAgent;
    private EnemyAI enemyAiClass;

    public GameObject robot;
    public float rotationSpeed = 5f;

    public Transform[] patrol;
    private int patrolDest = 0;
    public Transform playerPos;
    public Transform enemyPos;
    private Transform rotateRobot;

    private bool foundPlayer = false;
    private bool lookingForPlayer = true;

    private HudElements hudElementsClass;
    private PlayerMovement playerMovementClass;
    private SFX sfxClass;


    private void Awake()
    {
        rotateRobot = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //This originally was Find Object of Type, which takes the single instance of what im trying to find.
        // by doing Get Component, it takes the component ONLY from the object that its on (this)
        //GetComponent finds components (including scripts) on the same game object that the current script is on,
        //while FindObjectOfType searches through the scene and grabs the first instance of that type it finds.
        enemyAiClass = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        hudElementsClass = FindObjectOfType<HudElements>();
        playerMovementClass = FindObjectOfType<PlayerMovement>();
        sfxClass = FindObjectOfType<SFX>();
        Patrol();
    }

    private void Update()
    {
        RobotState();

    }




    public IEnumerator LostPlayer()
    {
        foundPlayer = false;
        //This currently isnt working
        Debug.Log("Starting Coroutine");
        navMeshAgent.destination = playerPos.position;
        yield return new WaitForSeconds(10);
        //Play sound
        Debug.Log("SPIN!"); // Continues to spin even if player is discovered, maybe put a break here.
        navMeshAgent.destination = enemyPos.position;
        StartCoroutine(Rotate(5));
        Debug.Log("Lost Position");
        yield return new WaitForSeconds(6);
        Debug.Log("Returning to Patrol.");

        lookingForPlayer = true;


    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;

        while (t < duration)
        {
            t += Time.deltaTime;

            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation,
            transform.eulerAngles.z);

            yield return null;
        }
    }


    private void RobotState()
    {
        if (enemyAiClass.IsPlayerInRange())
        {
            enemyState = EnemyState.Chase;
            ChangeState();
            foundPlayer = true;
            lookingForPlayer = false;

        }
        if (!enemyAiClass.IsPlayerInRange() && foundPlayer)
        {
            enemyState = EnemyState.Search;
            ChangeState();
        }
        if (!enemyAiClass.IsPlayerInRange() && lookingForPlayer)
        {
            enemyState = EnemyState.Patrol;
            ChangeState();
        }
        if (!enemyAiClass.IsPlayerInRange() && !foundPlayer)
        {
            return;
        }
    }

    private void Patrol()
    {
        //Debug.Log("Travelling to Patrol Point");
        navMeshAgent.destination = patrol[patrolDest].position;
        patrolDest = (patrolDest + 1) % patrol.Length;
    }


    private void ChasePlayer()
    {
        lookingForPlayer = false;
        navMeshAgent.destination = playerPos.position;
    }


    private void ChangeState()
    {
        switch (enemyState)
        {
            case EnemyState.Chase:
                {
                    ChasePlayer();
                }
                break;
            case EnemyState.Search:
                {
                    StartCoroutine(LostPlayer());
                }
                break;
            case EnemyState.Patrol:
                {
                    if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                    {
                        Patrol();
                    }
                }
                break;
            default:
                {
                    Debug.LogWarning("Something went Wrong");
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CaughtPlayer());
            //Debug.Log("I CAUGHT YOU");
        }
    }

    IEnumerator CaughtPlayer()
    {
        hudElementsClass.fadeToBlack.enabled = true;
        //sfxClass.StopChaseMusic();
        yield return null;
        sfxClass.PlayCaught();
        playerMovementClass.disableControls = true;
        playerMovementClass.Teleport();
        yield return new WaitForSeconds(6);
        hudElementsClass.fadeToBlack.enabled = false;
        playerMovementClass.disableControls = false;

    }

}
