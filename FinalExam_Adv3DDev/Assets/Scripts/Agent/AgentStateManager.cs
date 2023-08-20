using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateManager : MonoBehaviour
{
    // holds a reference to the active state in a state machine
    AgentBaseState currentState;
    public AgentWanderState WanderState = new AgentWanderState();
    public AgentChaseState ChaseState = new AgentChaseState();
    
    void Start()
    {
        // Starting state for the state machine 
        currentState = WanderState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(AgentBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
