using UnityEngine;

public class WaitingForOrder : IState
{
    public void Enter(EntityRestorant entity)
    {
        Client client = entity as Client;
        KitchenManager.instance.AddFoodOrder(client.clientOrder);
    }

    public void Exit(EntityRestorant entity)
    {
       
    }

    public void InState(EntityRestorant entity)
    {
        //ir a eating 
    }
}

