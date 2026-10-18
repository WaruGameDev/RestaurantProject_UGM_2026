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
        if(chef == null) return;
        // Delivering deja currentOrder en null, así que preguntamos directamente por null
        if(chef.currentOrder == null)
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
