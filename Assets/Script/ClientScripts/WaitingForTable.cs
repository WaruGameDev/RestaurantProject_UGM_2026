using UnityEngine;

public class WaitingForTable : IState
{
    Table target;
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
            target.SetOccupied(true);
            //entity.ChangeState(new SittingAtTable(new Food(), 2f));
            entity.ChangeState(new SittingAtTable());
        }
    }

    public void Exit(EntityRestorant entity) { }

    void TryAssignTable(EntityRestorant entity)
    {
        target = TableManager.instance.GetNearestTable(entity.transform.position);
        if (target != null) entity.meshAgent.SetDestination(target.transform.position);
    }
}
