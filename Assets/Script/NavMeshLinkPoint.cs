using UnityEngine;
using UnityEngine.AI;

public class NavMeshLinkPoint : MonoBehaviour
{
    public JumpWithDotween jumpWithDotween;
    public int indexOnJumpingSequence;

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<NavMeshAgent>()!=null)
        {
            NavMeshAgent meshAgent = other.GetComponent<NavMeshAgent>();
            if((indexOnJumpingSequence == 0 || 
        indexOnJumpingSequence == jumpWithDotween.points.Count-1) 
        && !jumpWithDotween.jumping)
        {            
            if(indexOnJumpingSequence == 0)
            {
                jumpWithDotween.Jumping(true, meshAgent);
            }
            else
            {
                jumpWithDotween.Jumping(false,meshAgent);
            }           
        }
        }
        
    }
    void OnDrawGizmos()
    {
        if(indexOnJumpingSequence == 0)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1);
        }
        else if(indexOnJumpingSequence == jumpWithDotween.points.Count-1)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 1);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, 1);
            
        }
    }


}
