using UnityEngine;

public class Cooking : IState
{
    public float timerToCook = 3;
    public float currentTimeToCook =0;
    public void Enter(EntityRestorant entity)
    {
        // timer de tiempo de cocina
        Debug.Log("cooking");
        currentTimeToCook = timerToCook;
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        if(currentTimeToCook >0)
        {
            currentTimeToCook-=1*Time.deltaTime;       
            if(currentTimeToCook<= 0)
            {
                entity.ChangeState(new Delivering());
            }
        }
    }
}
