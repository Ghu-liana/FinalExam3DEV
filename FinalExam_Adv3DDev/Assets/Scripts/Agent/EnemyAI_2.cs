using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_2 : MonoBehaviour
{
    private enum State
    {
        Patrolling,
        ChaseTarget,
    }
    private State state;

    public Transform agent;
    public float moveSpeed = 3f;
    public Transform target;
    NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    Vector3 targetV;

    int wayPointIndex;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        state = State.Patrolling;

        UpdateDestination();
    }

    void Update()
    {
        switch (state) // basic statemachine
        {
            case State.Patrolling:
                //patrolling code
                PatrolMovement();
                //while patrolling you look for target
                FindTarget();
                break;

            case State.ChaseTarget:
                navMeshAgent.SetDestination(target.position);
                moveSpeed = 7f;
                break;

            default:
                break;
        }
    }

    private void FindTarget()
    {
        float targetRange = 6f;
        if (Vector3.Distance(target.position, agent.position) < targetRange) // if player is within target range
        {
            state = State.ChaseTarget;
        }
        else // if target is not within range
        {
            state = State.Patrolling;
        }
    }

    void UpdateDestination()
    {
        targetV = waypoints[wayPointIndex].position;
        navMeshAgent.SetDestination(targetV);    
    }

    void IterateWaypointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
    }

    void PatrolMovement()
    {
        if (Vector3.Distance(transform.position,targetV) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
}
