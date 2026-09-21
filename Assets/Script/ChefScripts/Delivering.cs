using UnityEngine;

public class Delivering : IState
{
    public void Enter(EntityRestorant entity)
    {
        Debug.Log("Entregado");
        entity.meshAgent.SetDestination(KitchenManager.instance.deliveryPosition.position);   
        
    }

    public void Exit(EntityRestorant entity)
    {
        
    }

    public void InState(EntityRestorant entity)
    {
        if(entity.ArriveToDestination())
        {
            Chef chef = entity as Chef;
            KitchenManager.instance.AddFoodOrderReady(chef.currentOrder);
            chef.currentOrder = null;
            chef.ChangeState(new WaitingFoodOrder());
        }
    }

    
}
