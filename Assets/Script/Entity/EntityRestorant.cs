using UnityEngine;
using UnityEngine.AI;

public class EntityRestorant : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    public IState currentState;
    
    public void ChangeState(IState newState)
    {
        if(currentState != null) currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
    public bool ArriveToDestination()
    {
        return !meshAgent.pathPending 
        && meshAgent.remainingDistance <= meshAgent.stoppingDistance;
    }
    void Update()
    {
        currentState.InState(this);
    }
}
