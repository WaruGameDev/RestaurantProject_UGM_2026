using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AntController : MonoBehaviour
{
    public enum AntStates
    {
        WAITING,
        TO_SUGAR,
        GRABBING_SUGAR,
        TO_NEST,
        DROPPING_SUGAR   
    }
    public AntStates antCurrentState;
    public Transform target;
    public Transform nestTarget;
    public NavMeshAgent agent;
    public float distanceToGrab = .1f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        antCurrentState = AntStates.TO_SUGAR;
        yield break;

    }

    void Update()
    {
        switch(antCurrentState)
        {
            case AntStates.TO_SUGAR:
                agent.SetDestination(target.position);
                if(!agent.pathPending && agent.remainingDistance <= distanceToGrab)
                {                    
                    antCurrentState = AntStates.GRABBING_SUGAR;
                }
                break;
            case AntStates.GRABBING_SUGAR:
                target.SetParent(transform);
                antCurrentState = AntStates.TO_NEST;
                break;
            case AntStates.TO_NEST:
                agent.SetDestination(nestTarget.position);
                if(!agent.pathPending && agent.remainingDistance <= distanceToGrab)
                {
                    antCurrentState = AntStates.DROPPING_SUGAR;
                }
                break;
            case AntStates.DROPPING_SUGAR:
                target.SetParent(null);
                antCurrentState = AntStates.WAITING;
                break;


        }
    }


}
