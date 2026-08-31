using UnityEngine;
using UnityEngine.AI;

public class FollowTransform : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
   
    void Update()
    {
        agent.SetDestination(target.position);

        
    }
}
