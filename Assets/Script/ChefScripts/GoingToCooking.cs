using UnityEngine;

public class GoingToCooking : IState
{
    public void Enter(EntityRestorant entity)
    {
       
    }

    public void Exit(EntityRestorant entity)
    {
       
    }

    public void InState(EntityRestorant entity)
    {
        if(entity.ArriveToDestination())
        {
            entity.ChangeState(new Cooking());
        }
    }
}
