using UnityEngine;

public class WaitingFoodOrder : IState
{
    Chef chef;
    public void Enter(EntityRestorant entity)
    {
        chef = entity as Chef;
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        if (chef.currentOrder == null)
        {
            ActionNode choice = chef.decisionTree.Evaluate(chef);
            choice.Execute(chef);
            return;
        }
        if (entity.ArriveToDestination())
            entity.ChangeState(new Cooking());



    }
}
