using UnityEngine;

public class WaitingForOrder : IState
{
    Client client;
    public void Enter(EntityRestorant entity)
    {
        client = entity as Client;
        client.ChooseOrder();
        Debug.Log("pidió " + client.clientOrder.food.itemName);
        KitchenManager.instance.AddFoodOrder(client.clientOrder);
    }

    public void Exit(EntityRestorant entity)
    {
       
    }

    public void InState(EntityRestorant entity)
    {
        if(KitchenManager.instance.LookForClientOrder(client)== null) return;      
        // aquí interviene el Mesero
        KitchenManager.instance.readyClientOrders.Remove(KitchenManager.instance.LookForClientOrder(client));
        entity.ChangeState(new Eating());
    }
}

