using UnityEngine;

public class Leaving : IState
{

    public void Enter(EntityRestorant entity)
    {
        entity.meshAgent.SetDestination(TableManager.instance.door.position);
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
       
    }
}
