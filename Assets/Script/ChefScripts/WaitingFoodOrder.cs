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
        if(chef.currentOrder.currentOrder == "")
        {
            if(KitchenManager.instance.CheckHaveOrder())
            {
                chef.currentOrder = KitchenManager.instance.clientOrders[0];
                KitchenManager.instance.clientOrders.RemoveAt(0);     
                entity.meshAgent.SetDestination(KitchenManager.instance.cookingPosition.position);         
            }
            return;
        }
        if(entity.ArriveToDestination())
        {
            entity.ChangeState(new Cooking());
        }

        
    }
}
