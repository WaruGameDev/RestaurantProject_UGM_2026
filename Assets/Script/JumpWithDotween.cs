using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System.Drawing;


public class JumpWithDotween : MonoBehaviour
{
    public List<NavMeshLinkPoint> points;
    public bool jumping;
   
     
    public void Jumping(bool directionOfJumping, NavMeshAgent agent)
    {
        jumping = true;       
        agent.enabled = false;
        Sequence jumpingSequence = DOTween.Sequence();
        for(int i=0; i<points.Count; i++)
        {
            if(i == points.Count - 1) return;
            
            jumpingSequence.Append(agent.transform.DOJump
            (points[i+1].transform.position,1,1,.25f));            
            
        }

    }
   
   
    
}
