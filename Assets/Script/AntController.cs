using System.Collections;
using TMPro;
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
    public TextMeshPro stateText;
    public Transform target;
    public Transform nestTarget;
    public NavMeshAgent agent;
    public float distanceToGrab = .1f;

    

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
           /* case AntStates.WAITING:
                if(SugarManager.instance.sugarPosition.Count >0)
                {
                    target = SugarManager.instance.GetFirstSugar();
                    antCurrentState = AntStates.TO_SUGAR;
                }
                break;*/
        }
        stateText.text = antCurrentState.ToString();
    }


}
