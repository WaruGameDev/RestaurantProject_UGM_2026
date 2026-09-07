using UnityEngine;

public class WaitingForTable : IState
{
    TableRestorant target;
    public void Enter(EntityRestorant entity)
    {
        TryAssignTable(entity);
    }
    public void InState(EntityRestorant entity)
    {
        if (target == null)
        {
            TryAssignTable(entity);
            return;
        }

        if (entity.ArriveToDestination())
        {
            
            //entity.ChangeState(new SittingAtTable(new Food(), 2f));
            entity.ChangeState(new SittingAtTable());
        }
    }

    public void Exit(EntityRestorant entity) { }

    void TryAssignTable(EntityRestorant entity)
    {
        target = TableManager.instance.GetNearestTable(entity.transform.position);
        if (target != null) 
        {
            target.table.SetOccupied(true);
            target.client = (Client)entity;
            target.client.currentTable = target.table;
            entity.meshAgent.SetDestination(target.table.transform.position);

        }
    }
}
