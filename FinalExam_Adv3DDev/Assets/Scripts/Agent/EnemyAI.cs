using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Wandering,
        ChaseTarget,
    }

    public Transform agent;
    private State state;

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    public Transform target;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        state = State.Wandering;
    }

    private void Update()
    {
        switch (state) // basic statemachine
        {
            case State.Wandering:
                //wander code
                WanderMovement();
                //while wandering you look for target
                FindTarget();
                break;

            case State.ChaseTarget:
                navMeshAgent.SetDestination(target.position);
                break;

            default:
                break;
        }
    }

    private void FindTarget()
    {
        float targetRange = 4f;
        if(Vector3.Distance(target.position, agent.position) < targetRange) // if player is within target range
        {
            state = State.ChaseTarget;
        }
        else // if target is not within range
        {
            state = State.Wandering;
        }
    }

    void WanderMovement()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed); //Time.deltaTime so it is not affected by your frame rate
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed); // negative speed to rotate to the other side = automatically rotating left
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3); // the amount of time the capsule will be rotating
        int rotWait = Random.Range(1, 3); // time inbetween each time it rotates in seconds
        int rotateLorR = Random.Range(0, 3); // like a bool
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(2, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false; //so it can start the cycle all over again
    }
}
